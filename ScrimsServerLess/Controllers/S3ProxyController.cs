using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Amazon.S3;
using Amazon.S3.Model;

using Newtonsoft.Json;

namespace ScrimsServerLess.Controllers
{
    /// <summary>
    /// ASP.NET Core controller acting as a S3 Proxy.
    /// </summary>
    [Route("api/[controller]")]
    public class S3ProxyController : Controller
    {
        IAmazonS3 S3Client { get; set; }
        ILogger Logger { get; set; }

        string BucketName { get; set; }

        public S3ProxyController(ILogger<S3ProxyController> logger, IAmazonS3 s3Client)
        {
            this.Logger = logger;
            this.S3Client = s3Client;

            this.BucketName = Startup.Configuration[Startup.AppS3BucketKey];
            if(string.IsNullOrEmpty(this.BucketName))
            {
                logger.LogCritical("Missing configuration for S3 bucket. The AppS3Bucket configuration must be set to a S3 bucket.");
                throw new Exception("Missing configuration for S3 bucket. The AppS3Bucket configuration must be set to a S3 bucket.");
            }

            logger.LogInformation($"Configured to use bucket {this.BucketName}");
        }

        [HttpGet]
        public async Task<JsonResult> Get()
        {
            var listResponse = await this.S3Client.ListObjectsV2Async(new ListObjectsV2Request
            {
                BucketName = this.BucketName
            });

            try
            {
                this.Response.ContentType = "text/json";
                return new JsonResult(listResponse.S3Objects, new JsonSerializerSettings { Formatting = Formatting.Indented });
            }
            catch(AmazonS3Exception e)
            {

              
                this.Response.StatusCode = (int)e.StatusCode;
                return new JsonResult(e.Message);
            }
        }

        [HttpGet("{key}")]
        public async Task Get(string key)
        {
            try
            {
                var getResponse = await this.S3Client.GetObjectAsync(new GetObjectRequest
                {
                    BucketName = this.BucketName,
                    Key = key
                });

                this.Response.ContentType = getResponse.Headers.ContentType;
                getResponse.ResponseStream.CopyTo(this.Response.Body);
            }
            catch (AmazonS3Exception e)
            {
                this.Response.StatusCode = (int)e.StatusCode;
                var writer = new StreamWriter(this.Response.Body);
                writer.Write(e.Message);
            }
        }

         
        [HttpPost]
        public async Task<bool> Post(DTO.SmartImage smartImage)
        {
            // Copy the request body into a seekable stream required by the AWS SDK for .NET.
            byte[] byteresponse = Convert.FromBase64String(smartImage.ImageSrc);
            if (byteresponse != null)
            {
                this.Logger.LogInformation($"byteresponse is non empty");
                var seekableStream = new MemoryStream(byteresponse);

                var putRequest = new PutObjectRequest
                {
                    BucketName = this.BucketName,
                    Key = smartImage.ImageName,
                    InputStream = seekableStream

                };

                try
                {
                    var response = await this.S3Client.PutObjectAsync(putRequest);
                    Logger.LogInformation($"Uploaded object {smartImage.CIID} to bucket {this.BucketName}. Request Id: {response.ResponseMetadata.RequestId}");
                    return !String.IsNullOrEmpty(response.ETag);
                }
                catch (AmazonS3Exception e)
                {
                    this.Logger.LogInformation($"Exception in  POst smartimage {e.Message + e.StackTrace}");
                    this.Response.StatusCode = (int)e.StatusCode;
                    var writer = new StreamWriter(this.Response.Body);
                    writer.Write(e.Message);
                }
            }
            return false;
        }

        [HttpDelete("{key}")]
        public async Task Delete(string key)
        {
            var deleteRequest = new DeleteObjectRequest
            {
                 BucketName = this.BucketName,
                 Key = key
            };

            try
            {
                var response = await this.S3Client.DeleteObjectAsync(deleteRequest);
                Logger.LogInformation($"Deleted object {key} from bucket {this.BucketName}. Request Id: {response.ResponseMetadata.RequestId}");
            }
            catch (AmazonS3Exception e)
            {
                this.Response.StatusCode = (int)e.StatusCode;
                var writer = new StreamWriter(this.Response.Body);
                writer.Write(e.Message);
            }
        }
    }
}

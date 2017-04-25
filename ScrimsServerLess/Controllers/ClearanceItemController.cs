using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScrimsServerLess.Models;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using Amazon.S3;

namespace ScrimsServerLess.Controllers
{

    public class ClearanceItemController : Controller
    {
        private ScrimsDbContext scrimsDbContext;
        private ILogger logger;
        private IAmazonS3 S3Client;

        public ClearanceItemController(ScrimsDbContext scrimsDbContext, ILogger<ClearanceItemController> logger, IAmazonS3 s3Client)
        {
            this.S3Client = s3Client;
            this.scrimsDbContext = scrimsDbContext;
            this.logger = logger;
        }
        // GET api/values
        [HttpGet("/api/CIs")]

        public async Task<IEnumerable<ClearanceItem>> Get()
        {
            var cis = scrimsDbContext.ClearanceItem.ToAsyncEnumerable();
            var ciList = await cis.ToList();
            return ciList;
           
        }

        private async void OpenConnection()
        {
            string page = "http://en.wikipedia.org/";

            // ... Use HttpClient.
            using (HttpClient client = new HttpClient())
            {
                this.logger.LogInformation("Started executing client.GetAsync");
                HttpResponseMessage response = await client.GetAsync(page);

            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            return Ok(value);
        }

        // PUT api/values/5
        [HttpPut("api/ClearanceItems/{id}")]
        public void Put(int id, [FromBody]DTO.ClearanceItem clearanceItem)
        {
            if(clearanceItem != null)
            {
                var cidb = scrimsDbContext.ClearanceItem.FirstOrDefault(it => it.Ciid == id);
                if(cidb != null)
                {
                    cidb.Ciname = clearanceItem.ClearanceItemName;
                    cidb.Cistatus = 1;
                    cidb.CreatedBy = 2;
                    cidb.CreatedDate = DateTime.Now;
                    cidb.DescOfUse = clearanceItem.UseDescription;
                    cidb.QuickDesc = clearanceItem.Description;
                    cidb.Tags = clearanceItem.Tags;
                    scrimsDbContext.SaveChanges();
                }
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [HttpGet("/api/ClearanceItems/{ciId}")]
        public DTO.ClearanceItem Get(int ciId)
        {
            
            var cidb= scrimsDbContext.ClearanceItem.FirstOrDefault(it => it.Ciid == ciId);
            return new DTO.ClearanceItem()
            {
                ClearanceItemName = cidb.Ciname,
                ClearanceItemID = cidb.Ciid,
                ClearanceItemUniqueId = cidb.CiuniqueId,
                CreatedByProduction = true,
                Description = cidb.QuickDesc,
                UseDescription = cidb.DescOfUse,
                Status = "One",
                CreatedBy = "Ravi",
                CreatedDate=cidb.CreatedDate.Value.ToString(),
                Tags=cidb.Tags
              
            };

        }

       
    }
}

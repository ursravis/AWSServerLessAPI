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

namespace ScrimsServerLess.Controllers
{
   
    public class ProjectsController : Controller
    {
        private ScrimsDbContext scrimsDbContext;
        private ILogger logger;

        public ProjectsController(ScrimsDbContext scrimsDbContext, ILogger<S3ProxyController>  logger)
        {
            this.scrimsDbContext = scrimsDbContext;
            this.logger = logger;
        }
        // GET api/values
        [HttpGet("/api/projects")]
       
        public async Task<IEnumerable<Project>> Get()
        {
            //try
            //{



                this.logger.LogInformation("Started executing projects");
                this.logger.LogInformation("total projects" + scrimsDbContext.Project.Count());
                var projcts = scrimsDbContext.Project.ToAsyncEnumerable();
                this.logger.LogInformation("Started executing projects1");
                var projs = await projcts.ToList();
                this.logger.LogInformation("Started executing projects2");
                return projs;
                //var connectionString = @"Server=scrims-test.cnxbhgiegzg3.us-west-1.rds.amazonaws.com,1234;Database=scrims-test;User Id=scrimsadmin;Password=Testpassword#2;connection timeout=30";
                ////var connectionString = @"Server=.\SQLEXPRESS;Database=scrims-test;Trusted_Connection=True;";
                //using (SqlConnection connection = new SqlConnection(connectionString))
                //{
                //    if (connection.State != ConnectionState.Open)
                //    {
                //        this.logger.LogInformation("Opening Connection" + connection.State);
                //       await connection.OpenAsync();
                //    }
                //    this.logger.LogInformation("Opened Connection" + connection.State);

                //    SqlCommand command = new SqlCommand("Select * from Project", connection as SqlConnection);
                //    command.CommandType = CommandType.Text;
                //    DbDataReader ds= command.ExecuteReader(CommandBehavior.CloseConnection);
                //    if(ds != null && ds.HasRows)
                //    {
                //        this.logger.LogInformation("Started executing projects4"+ ds.FieldCount);
                //    }
                //}
               // return null;


            //}
            //catch(Exception ex)
            //{
            //    this.logger.LogError("Error From Code "+ ex.Message + ex.StackTrace);
            //    return null;
            //}
            this.logger.LogInformation("Started executing projects3");
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
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [HttpGet("/api/projects/{id}")]
        public async Task Get(int projectID)
        {
            this.logger.LogInformation("Started executing Get");
            string page = "http://en.wikipedia.org/";

            // ... Use HttpClient.
            using (HttpClient client = new HttpClient())
            {
                this.logger.LogInformation("Started executing client.GetAsync");
                using (HttpResponseMessage response = await client.GetAsync(page))
                using (HttpContent content = response.Content)
                {
                    this.logger.LogInformation("Started executing client.ReadAsStringAsync");
                    // ... Read the string.
                    string result = await content.ReadAsStringAsync();

                    // ... Display the result.
                    if (result != null &&
                        result.Length >= 50)
                    {
                        Console.WriteLine(result.Substring(0, 50) + "...");
                    }
                }
                this.logger.LogInformation("Started executing Get1");
            }
            // var project = scrimsDbContext.Project.FirstOrDefault(it => it.ProjectId == projectID);
            //if (project != null)
            //{
            //ScrimsServerLess.DTO.Project projObj = new ScrimsServerLess.DTO.Project();
            //    projObj.ProjectName = project.WorkingTitle ?? project.ReleaseTitle;
            //    projObj.TotalCICount = project.ClearanceItem != null ? project.ClearanceItem.Count : 0;
            //    projObj.ReviewQueueCount = project.ClearanceItem != null ? project.ClearanceItem.Where(it => it.ReviewQueue.HasValue && it.ReviewQueue.Value).Count() : 0;

            //    projObj.ProjectUniqueID = project.ProjectUniqueId;

            //    return projObj;
            //}


            //return new DTO.Project() { ProjectName = "test" };

        }

        [HttpGet("/api/dashboardProjects")]
        public IEnumerable<ScrimsServerLess.DTO.Project> GetListOfProjects()
        {
            OpenConnection();
            List<ScrimsServerLess.DTO.Project> projectList = new List<ScrimsServerLess.DTO.Project>();
          
                var statuses = scrimsDbContext.Cistatus.ToList();
                foreach (var project in scrimsDbContext.Project)
                {
                ScrimsServerLess.DTO.Project projObj = new ScrimsServerLess.DTO.Project();
                    projObj.ProjectName = project.WorkingTitle ?? project.ReleaseTitle;
                    projObj.TotalCICount = project.ClearanceItem != null ? project.ClearanceItem.Count : 0;
                    projObj.ReviewQueueCount = project.ClearanceItem != null ? project.ClearanceItem.Where(it => it.ReviewQueue.HasValue && it.ReviewQueue.Value).Count() : 0;
                    projObj.StatusNames = new List<string>();
                    projObj.StatusValues = new List<int>();
                    foreach (var status in statuses)
                    {
                        projObj.StatusNames.Add(status.Cistatus1);
                        projObj.StatusValues.Add(project.ClearanceItem != null ? project.ClearanceItem.Where(it => it.Cistatus.Value == status.CistatusId).Count() : 0);
                    }
                    projObj.ProjectUniqueID = project.ProjectUniqueId;
                    projectList.Add(projObj);
                }
            
            return projectList;
        }
    }
}

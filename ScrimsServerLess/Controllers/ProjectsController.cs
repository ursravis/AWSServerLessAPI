using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScrimsServerLess.Models;

namespace ScrimsServerLess.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        private ScrimsDbContext scrimsDbContext;

        public ProjectsController(ScrimsDbContext scrimsDbContext)
        {
            this.scrimsDbContext = scrimsDbContext;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Project> Get()
        {
            var projcts = this.scrimsDbContext.Project.ToList();
            return projcts;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
    }
}

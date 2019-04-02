using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Common.Models;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public IConfiguration _config;

        public ValuesController(IConfiguration config)
        {
            _config = config;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var itemResult = CategoryBl.GetAll();
            return new JsonResult(itemResult);

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var itemResult = CategoryBl.SingleOrDefault(x => x.Id == id);
            return new JsonResult(itemResult);
        }


        [HttpGet]
        [Route("GetSp")]
        public ActionResult<string> GetSp()
        {
            var connectionString = _config.GetConnectionString("DefaultConnection");
            string spname = "sp_Categories";
            var dt = SqlConnector.ReadFromSP(connectionString, spname);
            return new JsonResult(dt);
        }
        [HttpGet]
        [Route("GetSp/{id}")]
        public ActionResult<string> GetSp(int id)
        {
           var  connectionString = _config.GetConnectionString("DefaultConnection");
            string spname = "sp_Categories_Search";
            var p = new SqlParameter("@id", id);
            var dt = SqlConnector.ReadFromSP(connectionString, spname, p);
            return new JsonResult(dt);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] TblCategory category)
        {
            CategoryBl.Add(category);
            return new JsonResult("Success");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            CategoryBl.Delete(x => x.Id == id);
            return new JsonResult("Success");

        }
    }
}

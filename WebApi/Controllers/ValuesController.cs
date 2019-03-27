using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
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

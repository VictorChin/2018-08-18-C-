using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class Car {
        public int Doors { get; set; }
        public string Color{ get; set; }
    }
    public class Driver
    {
        public int Age { get; set; }
        public string Name{ get; set; }
    }
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet]
        public Driver Get(Car c) 
        {
            return new Driver { Age = 50, Name = "Bob" };
        }
        // GET api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
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

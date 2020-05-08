using BachelorsProjectWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BachelorsProjectWebApp
{
    public class Stringval
    {
        public string val { get; set; }
    }
    public class DataController : ApiController
    {
        DBMapper dbmapper = new DBMapper();
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]Stringval value)
        {
            //dbmapper.AddBeacon(value.val);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
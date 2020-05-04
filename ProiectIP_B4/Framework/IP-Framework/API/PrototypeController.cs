using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace IP_Framework.API
{
    [Route("api/Prototype")]
    [ApiController]
    public class PrototypeController : ControllerBase
    {
        // GET: api/Prototype
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Prototype/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("Diagnostic/{report}")]
        public string Get(String report)
        {
            return report + " primit";
        }

        // POST: api/Prototype
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpGet("Upload_image")]
        public string Get(bool ok)
        {
            Console.WriteLine("found something1");
            var client = new RestClient("http://localhost:2468/static/images/resources/tmp.png");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            System.IO.File.WriteAllBytes(@"image.png", Encoding.ASCII.GetBytes(response.Content));
            Console.WriteLine(response.Content);
            Console.WriteLine("found something5");
            return "blabla";
        }

        // PUT: api/Prototype/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

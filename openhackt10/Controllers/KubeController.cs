using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace openhackt10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KubeController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public KubeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        // GET: api/Kube
        [HttpGet]
        public async Task<IActionResult> Get()
        {   
            //sydneyopen-sydneyopenhackt1-1ecc8e-8fc658c3.hcp.australiaeast.azmk8s.io/api/v1/namespaces/default/services
            //return new string[] { "value1", "value2" };
            var client = _httpClientFactory.CreateClient("openhackAPI");
            
            var data = await client.GetAsync("api/v1/namespaces/default/services");
            return Ok(data);

        }

        // GET: api/Kube/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Kube
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Kube/5
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

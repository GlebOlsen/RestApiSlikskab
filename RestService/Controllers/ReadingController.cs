using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestService.Managers;
using RestService.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingController : ControllerBase
    {
        private static ReadingsManager _manager = new ReadingsManager(ReadingsManager.TestData);
        // GET: api/<ReadipngsController>
        [HttpGet]
        public IEnumerable<Reading> Get()
        {
            return _manager.GetAll();
        }

        // GET api/<ReadipngsController>/5
        [HttpGet("{id}")]
        public Reading Get(int id)
        {
            return _manager.GetById(id);
        }

        // POST api/<ReadipngsController>
        [HttpPost]
        public Reading Post([FromBody] Reading value)
        {
            return _manager.Post(value);
        }

        // PUT api/<ReadipngsController>/5
        [HttpPut("{id}")]
        public Reading Put(int id, [FromBody] Reading value)
        {
            return _manager.Update(id, value);
        }

        // DELETE api/<ReadipngsController>/5
        [HttpDelete("{id}")]
        public Reading Delete(int id)
        {
            return _manager.Delete(id);
        }
    }
}

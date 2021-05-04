﻿using System;
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
        private ReadingsManager _manager = new ReadingsManager(ReadingsManager.TestData);
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
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ReadipngsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReadipngsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

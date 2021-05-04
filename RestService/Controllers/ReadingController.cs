using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        private static string _idNotFoundMessage = $"Could not find reading with id ";
        // GET: api/<ReadipngsController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Reading>> Get()
        {
            return Ok(_manager.GetAll());
        }

        // GET api/<ReadipngsController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Reading> Get(int id)
        {
            Reading reading = _manager.GetById(id);
            if (reading == null)
            {
                return NotFound(_idNotFoundMessage + id);
            }
            else
            {
                return Ok(_manager.GetById(id));
            }
        }

        // POST api/<ReadipngsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Reading> Post([FromBody] Reading value)
        {
            try
            {
                Reading reading = _manager.Post(value);
                string url = Url.RouteUrl(RouteData.Values) + "/" + reading.ReadingId;
                return Created(url, reading);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ReadipngsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Reading> Put(int id, [FromBody] Reading value)
        {
            try
            {

                Reading reading = _manager.Update(id, value);
                if (reading == null)
                {
                    return NotFound(_idNotFoundMessage + id);
                }
                else
                {
                    return Ok(reading);
                }
            }catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ReadipngsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Reading> Delete(int id)
        {
            Reading reading = _manager.Delete(id);
            if(reading == null)
            {
                return NotFound(_idNotFoundMessage + id);
            }
            else
            {
                return Ok(reading);
            }

        }
    }
}

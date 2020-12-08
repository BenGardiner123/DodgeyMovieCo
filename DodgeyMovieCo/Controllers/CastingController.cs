﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DodgeyMovieCo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastingController : ControllerBase
    {
        // GET: api/<CastingController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CastingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CastingController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CastingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CastingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
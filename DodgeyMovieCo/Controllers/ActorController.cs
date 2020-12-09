using DodgeyMovieCo.Models;
using DodgeyMovieCo.MovieClassLb;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DodgeyMovieCo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {

        private DatabaseLayer _DatabaseLayer;

        public ActorController(DatabaseLayer databaseLayer)
        {
            this._DatabaseLayer = databaseLayer;
        }


        // PUT api/<MovieController>/DeppJohnny
        [Route("ChangeActorName")]
        [HttpPatch]
        public ActionResult<Actor> UpdateActorNAme([FromBody] UpdateActorNameRequest updateActorName)
        {
            var result = _DatabaseLayer.updateActor(updateActorName);
            return Ok(result);
        }

    }
}

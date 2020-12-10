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
        public ActionResult UpdateActorNAme([FromBody] UpdateActorNameRequest updateActorName)
        {
            
            var selected_result = "";
            var result = _DatabaseLayer.GetActor(updateActorName);
            if (result == null)
            {
                return BadRequest();
            }
            else
            {
                Actor actor = result;
                actor.Surname = updateActorName.NewSurname;
                actor.setFullName();
                selected_result = _DatabaseLayer.UpdateActorName(actor);
            }
           

            return Ok(selected_result);
        }


        // POST api/<MovieController>/NewActor
        [Route("CreateUserActor")]
        [HttpPost]
        public ActionResult<Actor> Post([FromBody] Actor newActor)
        {
            Actor actor = newActor;
            actor.ActorNo = _DatabaseLayer.getNextActorNum();
            var output = _DatabaseLayer.CreateNewactor(actor);
            return Ok(output);

        }

        // POST api/<MovieController>/CastActorIntoNewMovie
        [HttpPost("CastActorIntoMovie")]
        public ActionResult<Movie> Post([FromBody] Casting newCasting)
        {
            var selected_result = new List<string>();
            var getNextCasting = _DatabaseLayer.getNextcastingNum();
            newCasting.CastID = getNextCasting;
            var result = _DatabaseLayer.CastActorIntoMovie(newCasting);
            if (result == null)
            {
                return BadRequest();
            }
            else
            {
                selected_result = _DatabaseLayer.checkCasting(result.ActorNo);
            }


            return Ok(selected_result);


        }

    }
}

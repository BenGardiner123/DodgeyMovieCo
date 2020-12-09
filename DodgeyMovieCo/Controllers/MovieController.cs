using DodgeyMovieCo.Models;
using DodgeyMovieCo.MovieClassLb;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DodgeyMovieCo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class MovieController : ControllerBase
    {

        private DatabaseLayer _DatabaseLayer;

        public MovieController(DatabaseLayer databaseLayer)
        {
            this._DatabaseLayer = databaseLayer;
        }

        /* [Route("TotalCasting")]
         [HttpGet]
         public ActionResult ActorTotal()
         {
             Casting c1 = new Casting();
             return Ok(c1.getAllCastings(connectionString));
         }*/


        /*  // GET: api/<MovieController>/NumActors

          [Route("NumActors/{movieNum}")]
          [HttpGet]
          public List<NumActorsResponseModel> ActorTotal(int movieNum)
          {
              Movie m2 = new Movie();
              return m2.NumActors(connectionString, movieNum);
          }
  */


        /*      // GET: api/<MovieController>/MovieAge
              [Route("MovieAge/{movieTitle}")]
              [HttpGet]
              public int GetMovieAge(string movieTitle)
              {
                  Movie m2 = new Movie();
                  return m2.GetAge(connectionString, movieTitle);

              }*/


        //ReadTask1
        // GET: /<MovieController>/AllMovies
        [Route("AllMovies")]
        [HttpGet]
        public ActionResult<List<Movie>> GetAllMovies()
        {
            var output = _DatabaseLayer.GetAllMovies();
            return output;
        }
        
       // GET api/<MovieController>/The
        [Route("TitleContainsThe")]
        [HttpGet]
        public List<string> TitlesThatBeginWith()
        {
            var output = _DatabaseLayer.TitlesThatBeginWith();
            return output;
        }
    

        // GET <MovieController>/LukeWilsonsMovieList
        [Route("LukeWilsonsMovieList")]
        [HttpGet]
        public List<string> getLukeWilsonsMovieTitles() 
        {
            var output = _DatabaseLayer.getLukeWilsonsMovieTitles();
            return output;
        }



       // GET api/<MovieController>/RunningTimes
        [Route(("RunningTimes"))]
        [HttpGet]
        public string GetTotalMovieRunTime()
        {
            var output = _DatabaseLayer.GetTotalMovieRunTime();
            return output;
        }


        //update task 1
        // PUT api/<MovieController>/ChangeRuntime
        [Route("ChangeRuntime")]
        [HttpPatch]
        public ActionResult<Movie> ChangeMovieRuntime([FromBody] UpdateRuntimeRequestModel userUpdateRequest)
        {
            var output = _DatabaseLayer.ChangeMovieRuntime(userUpdateRequest);
            return Ok(output);
        }

          
        
        
  


       
    /*    // POST api/<MovieController>/CreateNewMovie
        [Route("CreateUserMovie")]
        [HttpPost]
        public ActionResult<Movie> Post([FromBody] Movie newUserMovie)
        {
            
            string query1 = "INSERT INTO MOVIE (MovieNum, Title, ReleaseYear, RunTime) " +
                           $"VALUES ({newUserMovie.MovieNum}, {newUserMovie.Title}, {newUserMovie.ReleaseYear}, {newUserMovie.RunTime}) ";

            // create connection and command
            SqlConnection connecting = new SqlConnection(connectionString);

            SqlCommand createNewMovie= new SqlCommand(query1, connecting);

            try
            {
                connecting.Open();
                createNewMovie.ExecuteNonQuery();
                connecting.Close();
            }
            catch (SqlException ex)
            {
                throw new ApplicationException($"Some sql error happened + {ex}");
            }

            return Ok();
        }
*/




/*
       // POST api/<MovieController>/NewActor
       [Route("CreateUserActor")]
       [HttpPost]
       public ActionResult Post([FromBody] Actor newActor)
       {
            

            string query1 = "INSERT INTO Actor (ActorNo, FullName, GivenName, Surname) " +
                           $"VALUES ({newActor.ActorNo}, {newActor.FullName}, {newActor.GivenName}, {newActor.Surname}) ";

            // create connection and command
            SqlConnection connecting = new SqlConnection(connectionString);

            SqlCommand createNewActor = new SqlCommand(query1, connecting);

            try
            {
                connecting.Open();
                createNewActor.ExecuteNonQuery();
                connecting.Close();
            }
            catch (SqlException ex)
            {
                throw new ApplicationException($"Some sql error happened + {ex}");
            }

            return Ok();
       }
    */
       
        
       
   /*    // POST api/<MovieController>/CastActorIntoNewMovie
       [HttpPost]
       public ActionResult<Movie> Post([FromBody] Casting newCasting)
        {
            

            string query1 = "INSERT INTO CASTING (CastID, ActorNo, MoveieNo) " +
                           $"VALUES ({newCasting.CastID}, {newCasting.ActorNo}, {newCasting.MoveieNo}) ";

            // create connection and command
            SqlConnection connecting = new SqlConnection(connectionString);

            SqlCommand createNewActor = new SqlCommand(query1, connecting);

            try
            {
                connecting.Open();
                createNewActor.ExecuteNonQuery();
                connecting.Close();
            }
            catch (SqlException ex)
            {
                throw new ApplicationException($"Some sql error happened + {ex}");
            }

            return Ok();
       }
*/
       
    }
}

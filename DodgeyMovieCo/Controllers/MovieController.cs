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
        // PUT /<MovieController>/ChangeRuntime
        [Route("ChangeRuntime")]
        [HttpPatch]
        public ActionResult<Movie> ChangeMovieRuntime([FromBody] UpdateRuntimeRequestModel userUpdateRequest)
        {
            var output = _DatabaseLayer.ChangeMovieRuntime(userUpdateRequest);
            return Ok(output);
        }

         
         // POST /<MovieController>/CreateNewMovie
        [Route("CreateUserMovie")]
        [HttpPost]
        public ActionResult<NewMovieRequestModel> Post([FromBody] NewMovieRequestModel newUserMovie)
        {
            var nextValue = _DatabaseLayer.getNextMovieNum();
            var result = _DatabaseLayer.CreateNewMovie(nextValue, newUserMovie);
            
            var check = _DatabaseLayer.getAMovie(result.Title);

            if(check == result.Title)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
       
    }
}

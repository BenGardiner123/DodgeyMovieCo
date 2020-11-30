using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DodgeyMovieCo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        // GET: api/<MovieController>
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {

            //Create the movie list
            //ReadOnlyMemory everything into it
            //here    
            //return movie
        }

        // GET api/<MovieController>/The
        [HttpGet("{searchWord}")]
        public List<Movie> Get(string searchWord)
        {
            //access the database and display the titles for all the movies 
            //with title that begin with the word “The” (case insensitive)
                return movieList;
        }

        // GET api/<MovieController>/Luke Wilson
        [HttpGet("{actors' name}")]
        public List<Movie> Get(string searchWord)
        {
            //Access the database and display all the titles for 
            //all movies that Luke Wilson has been cast in
            return movieList;
        }

        // GET api/<MovieController>/Luke Wilson
        [HttpGet("RunningTime")]
        public List<Movie> Get(string searchWord)
        {
            //Using the list Movies created in step one, 
            //display the total running time of all movies
            return movieList;
        }


        // PUT api/<MovieController>/Ghostbusters
        [HttpPut("{movie title}")]
        public ActionResult<Movie> Put([FromBody] string newMovieTitle)
        {
            //1.In your program, provide a way to change a movie’s runtime found by title.
            //New title to be obtained via user input.  Change must be reflected in the DB.
            return Ok();
        }

        // PUT api/<MovieController>/DeppJohnny
        [HttpPut("{id}")]
        public ActionResult<Actor> Put([FromBody] string surname, string givenName)
        {
            //Provide a way to change an actor’s surname and fullname, found by givenname and surname. 
            //New surname to obtained via user input.Change must be reflected in the DB.
            return Ok();
        }

        // POST api/<MovieController>/CreateNewMovie
        [HttpPost]
        public ActionResult<Movie> Post([FromBody] Movie newMovie)
        {
            return Ok(newMovie);
        }

        // POST api/<MovieController>/NewActor
        [HttpPost]
        public ActionResult<Actor> Post([FromBody] Actor newActor)
        {
            return Ok(newActor);
        }

        // POST api/<MovieController>/CastActorIntoNewMovie
        [HttpPost]
        public ActionResult<Movie> Post([FromBody] Actor actor, Movie targetMovie)
        {
            return Ok(targetMovie);
        }


        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

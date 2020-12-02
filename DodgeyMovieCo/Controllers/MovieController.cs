using DodgeyMovieCo.Models;
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

        IConfiguration configuration;
        // have to add this using nuget sqldataclient
        SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();

        public string connectionString;

        public MovieController(IConfiguration iConfig)
        {
            this.configuration = iConfig;

            this.stringBuilder.DataSource = this.configuration.GetSection("DBConnectionStrings").GetSection("Url").Value;
            this.stringBuilder.InitialCatalog = this.configuration.GetSection("DBConnectionStrings").GetSection("Database").Value;
            this.stringBuilder.UserID = this.configuration.GetSection("DBConnectionStrings").GetSection("User").Value;
            this.stringBuilder.Password = this.configuration.GetSection("DBConnectionStrings").GetSection("Password").Value;
            this.connectionString = this.stringBuilder.ConnectionString;
        }


        // GET: api/<MovieController>/NumActors

        [Route("NumActors/{movieNum}")]
        [HttpGet]
        public List<NumActorsResponseModel> ActorTotal(int movieNum)
        {
            Movie m2 = new Movie();
            return m2.NumActors(connectionString, movieNum);
        }



        // GET: api/<MovieController>/MovieAge
        [Route("MovieAge/{movieTitle}")]
        [HttpGet]
        public int GetMovieAge(string movieTitle)
        {
            Movie m2 = new Movie();
            return m2.GetAge(connectionString, movieTitle);

        }







        //ReadTask1
        // GET: api/<MovieController>/AllMovies
        [Route("Test")]
        [HttpGet]
        public List<Movie> GetAllMovies()
        {
            ActorRessponseModel movie1 = new ActorRessponseModel();
            Movie m1 = new Movie();

            string query1 = "select * from Movie";

            // create connection and command
            SqlConnection connecting = new SqlConnection(connectionString);

            SqlCommand getActorsCmd = new SqlCommand(query1, connecting);
           
            try
            {
                connecting.Open();

                using (SqlDataReader reader = getActorsCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // ORM - Object Relation Mapping
                        movie1.Movies.Add(
                            // major problem here was that float in SQL and float in c# are different - so was throwing a casting error - winratio had to be cast as a "single"
                            new Movie()
                            {
                                MovieNum = Convert.ToInt32(reader[0]),
                                Title = reader[1].ToString(),
                                ReleaseYear = Convert.ToInt32(reader[2]),
                                RunTime = (Convert.ToInt32(reader[3]))
                            });
                    
                    }

                    reader.Close();
                }

                connecting.Close();
            }
            catch (SqlException ex)
            {
                throw new ApplicationException($"Some sql error happened + {ex}");
            }


            return movie1.Movies;



        }



      

        
        /*
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
        }*/

      /*  // PUT api/<MovieController>/Ghostbusters
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
        }*/
    }
}

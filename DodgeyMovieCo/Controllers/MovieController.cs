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
    

  /*      // GET api/<MovieController>/Luke Wilson
        [Route("LukeWilson")]
        [HttpGet]
        public List<string> getLukeWilsonsMovieTitles() { 

            //access the database and display the titles for all the movies 
            //that Luke Wilson starred in
            CastingResponseModelEnvelope movieResposne = new CastingResponseModelEnvelope();
            //this is wehre the titles will go after they're pulled out o fthe db'
            List<string> titles = new List<string>();

            string query1 =    "SELECT M.MOVIENO, M.TITLE, M.RELYEAR, M.RUNTIME " +
                               "FROM MOVIE M " +
                               "INNER JOIN CASTING C " +
                               "ON C.MOVIENO = M.MOVIENO " +
                               "INNER JOIN ACTOR A " +
                               "ON C.ACTORNO = A.ACTORNO " +
                               "WHERE c.actorno = 36422 ";
            

            // create connection and command
            SqlConnection connecting = new SqlConnection(connectionString);

            SqlCommand getMovies = new SqlCommand(query1, connecting);

            try
            {
                connecting.Open();

                using (SqlDataReader reader = getMovies.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // ORM - Object Relation Mapping
                        movieResposne.Movies.Add(
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

            //using LINQ to filter all the strings out of the list -which wil be only the titles
            var result = movieResposne.Movies.OfType<string>();


            // Loop through the collection and add all those titles to a list and then return them
            foreach (var title in result)
            {
                titles.Add(title);
            }

            return titles;



        }
*/


  /*     // GET api/<MovieController>/RunningTimes
        [Route(("RunningTimes"))]
        [HttpGet]
        public string GetTotalMovieRunTime()
        {
            //Using the list Movies created in step one, 
            //display the total running time of all movies
            
            //create a list of int's to hold each movies runtimes
            List<int> runningTimeOutput = new List<int>();

            //for each movie pull out theruntime and stick it inside the other list 
            foreach (var movie in staticResultsHolder)
            {
                runningTimeOutput.Add(movie.RunTime);
            }
            //calc all the int's inside the list
            int sumOfAll = runningTimeOutput.Sum();

            return $"the total runtime all of the moveisa in the list is {sumOfAll} mins";
        }
  */

 /*       //update task 1
        // PUT api/<MovieController>/ChangeRuntime
        [Route("ChangeRuntime")]
        [HttpPut]
        public ActionResult<Movie> Put([FromBody] UpdateRuntimeRequestModel userUpdateRequest)
        {
            //1.In your program, provide a way to change a movie’s runtime found by title.
            //New title to be obtained via user input.  Change must be reflected in the DB.
            CastingResponseModelEnvelope movie1 = new CastingResponseModelEnvelope();

            string query1 = "UPDATE MOVIE " +
                            $"SET RUNTIME = {userUpdateRequest.RunTime} " +
                            $"where LOWER m.title like LOWER ('%{userUpdateRequest.Title}%') " +
                            "Select * from MOVIE " +
                            $"where LOWER m.title like LOWER ('%{userUpdateRequest.Title}%') ";


            // create connection and command
            SqlConnection connecting = new SqlConnection(connectionString);

            SqlCommand changeRuntime = new SqlCommand(query1, connecting);

            try
            {
                connecting.Open();

                using (SqlDataReader reader = changeRuntime.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // ORM - Object Relation Mapping
                        movie1.Movies.Add(
                            // pushing the mapped object intot a new object and pushing to the list.
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

            return Ok(movie1.Movies);
        }
        */
        
    /*    // PUT api/<MovieController>/DeppJohnny
        [Route("ChangeActorName")]
        [HttpPut]
        public ActionResult<Actor> Put([FromBody] UpdateActorNameRequest updateActorName)
        {
            //Provide a way to change an actor’s surname and fullname, found by givenname and surname. 
            //New surname to obtained via user input.Change must be reflected in the DB.
            ActorResponseModel actorResponse = new ActorResponseModel();


            string setName = "UPDATE ACTOR A " +
                             $"SET A.SURNAME = {updateActorName.NewSurname} " +
                             $"SET A.FULLNAME = A.GIVENNAME + ' ' + '{updateActorName.NewSurname}' " +
                             $"WHERE A.GIVENNAME = {updateActorName.GivenName} AND A.SURNAME = {updateActorName.Surname}" +
                             " GO " + 
                             "SELECT * FROM ACTOR " +
                             $"WHERE A.GIVENNAME = { updateActorName.GivenName} AND A.SURNAME = { updateActorName.Surname} ";
            


            // create connection and command
            SqlConnection connecting = new SqlConnection(connectionString);
            SqlCommand setActorNameUsingSurnameAndFullname = new SqlCommand(setName, connecting);

            try
            {
                connecting.Open();

                using (SqlDataReader reader = setActorNameUsingSurnameAndFullname.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // ORM - Object Relation Mapping
                        actorResponse.Actors.Add(
                                new Actor()
                                {
                                    ActorNo = Convert.ToInt32(reader[0]),
                                    FullName = reader[1].ToString(),
                                    GivenName = reader[2].ToString(),
                                    Surname = reader[3].ToString()
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



            return Ok(actorResponse.Actors);


        }*/


       
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

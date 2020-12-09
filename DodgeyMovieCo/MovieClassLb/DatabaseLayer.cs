using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DodgeyMovieCo.MovieClassLb
{
    public class DatabaseLayer
    {

        
        IConfiguration configuration;
        // have to add this using nuget sqldataclient
        SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
        public string connectionString;



        public DatabaseLayer(IConfiguration iConfig)
        {
            
            this.configuration = iConfig;
            this.stringBuilder.DataSource = this.configuration.GetSection("DBConnectionStrings").GetSection("Url").Value;
            this.stringBuilder.InitialCatalog = this.configuration.GetSection("DBConnectionStrings").GetSection("Database").Value;
            this.stringBuilder.UserID = this.configuration.GetSection("DBConnectionStrings").GetSection("User").Value;
            this.stringBuilder.Password = this.configuration.GetSection("DBConnectionStrings").GetSection("Password").Value;
            this.connectionString = this.stringBuilder.ConnectionString;
        }



        public string dbRedirect()
        {

            SqlConnectionStringBuilder dodgyestringBuilder = new SqlConnectionStringBuilder();
            dodgyestringBuilder.DataSource = "no.database.here.com";
            dodgyestringBuilder.InitialCatalog = "Is";
            dodgyestringBuilder.UserID = "Wally";
            dodgyestringBuilder.Password = "Where";


            // create connection and command
            /*
             implementing this inside the brackets makes sure that all open connections are terminated
             */
            try
            {
                var query = "select * from sys.tables";

                using (SqlConnection conn = new SqlConnection(dodgyestringBuilder.ConnectionString))
                {
                    var command = new SqlCommand(query, conn);
                    conn.Open();
                }
                return "conenction failed";

            }
            //hopefully we do the same thing below but wuth te right details  - then when this fails the code below will execute
            //taken from https://stackoverflow.com/questions/434864/how-to-check-if-connection-string-is-valid
            catch (SqlException ex)
            {

                try
                {
                    
                    using (SqlConnection conn = new SqlConnection(this.connectionString))
                    { 
                        conn.Open();
                        conn.Close();
                        return " There was an inital error with your account however connection redirected succesfully ! - - " + ex.Message;
                    }
                    
                }
                catch (SqlException SqlEx)
                {
                    return "Uh oh those dodgey connection details created a much larger issue " + SqlEx;
                }

                
            }
           


        }

        
        public List<Movie> GetAllMovies()
        {
            List<Movie> Movies = new List<Movie>();
            
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
                        Movies.Add(
                            
                            new Movie()
                            {
                                MovieNum = Convert.ToInt32(reader[0]),
                                Title = reader[1].ToString(),
                                ReleaseYear = Convert.ToInt16(reader[2]),
                                RunTime = Convert.ToInt16(reader[3])
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

            return Movies;
        }


        public List<string> TitlesThatBeginWith()
        {
            //access the database and display the titles for all the movies 
            //with title that begin with the word “The” (case insensitive)
            MovieDatabaseserverRespnse movieResposne = new MovieDatabaseserverRespnse();
            //this is wehre the titles will go after they're pulled out o fthe db'
            List<string> titles = new List<string>();

            string query1 = "select * from Movie M " +
                            "where LOWER (M.TITLE) LIKE LOWER ('%The%')";

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
                                ReleaseYear = Convert.ToInt16(reader[2]),
                                RunTime = Convert.ToInt16(reader[3])
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
            var result = movieResposne.Movies;


            // Loop through the collection and add all those titles to a list and then return them
            foreach (var movie in result)
            {
                titles.Add(movie.Title);
            }

            return titles;



        }

        public List<string> getLukeWilsonsMovieTitles()
        {

            //access the database and display the titles for all the movies 
            //that Luke Wilson starred in
            MovieDatabaseserverRespnse movieResposne = new MovieDatabaseserverRespnse();
            //this is wehre the titles will go after they're pulled out o fthe db'
            List<string> titles = new List<string>();

            string query1 = "SELECT M.MOVIENO, M.TITLE, M.RELYEAR, M.RUNTIME " +
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
                                ReleaseYear = Convert.ToInt16(reader[2]),
                                RunTime = Convert.ToInt16(reader[3])
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
            var result = movieResposne.Movies;


            // Loop through the collection and add all those titles to a list and then return them
            foreach (var movie in result)
            {
                titles.Add(movie.Title);
            }

            return titles;



        }








    }
}

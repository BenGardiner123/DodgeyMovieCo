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

        //DBNull cononection stuff goes here
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
                using (SqlConnection conn = new SqlConnection(dodgyestringBuilder.ConnectionString))
                {
                    var query = "select * from sys.tables";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        // open connection, execute INSERT, close connection
                        conn.Open();
                        //apparently when you .open it should throw the error here
                        conn.Close();


                    }

                }

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
                        return "Connection redirected succesfully" + ex.Message;
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

            staticResultsHolder = movie1.Movies.ToList();

            return movie1.Movies;



        }

    }
}

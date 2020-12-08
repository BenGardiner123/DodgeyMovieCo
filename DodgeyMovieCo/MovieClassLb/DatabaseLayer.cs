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
            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder()
            {

            }
            public string connectionString;
            

            // create connection and command
            using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // define parameters and their values
                        cmd.Parameters.Add("@dateTimeStarted", SqlDbType.DateTime).Value = angularGameRequest.DateTimeStarted;
                        cmd.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = angularGameRequest.Username;
                        cmd.Parameters.Add("@Numrounds", SqlDbType.Int).Value = angularGameRequest.roundLimit;

                        // open connection, execute INSERT, close connection


                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();


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

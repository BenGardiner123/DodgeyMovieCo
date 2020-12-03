using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DodgeyMovieCo.Models
{
    public class Casting
    {
        public int CastID { get; set; }
        public int ActorNo { get; set; }
        public int MoveieNo { get; set; }

    }

   
    public List<Movie> getAllCastings(string connectionString)
    {
        MovieDataBseResponseModel movie1 = new MovieDataBseResponseModel();
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

        staticResultsHolder = movie1.Movies.ToList();

        return movie1.Movies;



    }
}

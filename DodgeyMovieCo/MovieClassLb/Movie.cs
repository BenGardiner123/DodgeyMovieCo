using DodgeyMovieCo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DodgeyMovieCo
{
    
    public class Movie
    {
        public int MovieNum { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public int RunTime { get; set; }
        public List<Actor> ActorList { get; set; }


        public Movie()
        {
           

        }

     

        public List<NumActorsResponseModel> NumActors(string connectionString, int MovieNum) {
            NumActorsResponseEnvelope r1 = new NumActorsResponseEnvelope();
            Movie m1 = new Movie();

            string ActorsCount = "select COUNT(C.ACTORNO) " +
                                 "FROM MOVIE M " +
                                 "INNER JOIN CASTING C " +
                                 "ON C.MOVIENO = M.MOVIENO " +
                                 $"WHERE M.MOVIENO = '{MovieNum}'";
                                
            // create connection and command
            SqlConnection connecting = new SqlConnection(connectionString);
            SqlCommand getActorsCmd = new SqlCommand(ActorsCount, connecting);
            
            try
            {
                connecting.Open();

                using (SqlDataReader reader = getActorsCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // ORM - Object Relation Mapping
                        r1.numberAct.Add(
                            new NumActorsResponseModel() 
                            { 
                                NumActors = (int)reader[0]
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


            return r1.numberAct;


        }



        public int GetAge(string connectionString, string MovieTitle)
        {
            CastingResponseModelEnvelope movieResponse = new CastingResponseModelEnvelope();
            Movie m1 = new Movie();

            string MovieAge = "SELECT M.MOVIENO, M.TITLE, M.RELYEAR, M.RUNTIME " +
                                 "FROM MOVIE M " +
                                 "INNER JOIN CASTING C " +
                                 "ON C.MOVIENO = M.MOVIENO " +
                                 $"WHERE M.TITLE = '{MovieTitle}'";

            // create connection and command
            SqlConnection connecting = new SqlConnection(connectionString);
            SqlCommand getMovieAgeCmd = new SqlCommand(MovieAge, connecting);

            try
            {
                connecting.Open();

                using (SqlDataReader reader = getMovieAgeCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // ORM - Object Relation Mapping
                        movieResponse.Movies.Add(
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

            var relyearOutput = 0;
            relyearOutput = movieResponse.Movies[2].ReleaseYear;
            relyearOutput = 2020 - relyearOutput;

            return relyearOutput;


        }
            

    }
}

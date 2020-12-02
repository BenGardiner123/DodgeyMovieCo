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

        public Movie()
        {

        }

        public int NumActors(string connectionString, int MovieNum) {
            NumActorsResponseEnvelope numAct = new NumActorsResponseEnvelope();
            Movie m1 = new Movie();

            string ActorsCount = "select COUNT(C.ACTORNO) as Total" +
                                 "FROM MOVIE M" +
                                 "INNER JOIN CASTING C " +
                                 "ON C.MOVIENO = M.MOVIENO" +
                                 "WHERE M.MOVIENO = @MOVIENUM";
                                
            // create connection and command
            SqlConnection connecting = new SqlConnection(connectionString);

            SqlCommand getActorsCmd = new SqlCommand(ActorsCount, connecting);
            getActorsCmd.Parameters.Add("@MOVIENUM", SqlDbType.VarChar, 100).Value = MovieNum;
            List<int> ActorCount = new List<int>();

            try
            {
                connecting.Open();

                using (SqlDataReader reader = getActorsCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // ORM - Object Relation Mapping
                        ActorCount.Add(Convert.ToInt32(reader["Total"]));

                    }
                    reader.Close();
                }

                connecting.Close();
            }
            catch (SqlException ex)
            {
                throw new ApplicationException($"Some sql error happened + {ex}");
            }

         
            return ActorCount.First();


        }



        public int GetAge(int MovieNum)
        {
            //returns how old the movie is from the current year as an int
            // so now i need to return the eladboard view into something then return that to angualr
            // not sure if i combine the two here or just use the SQLdataclient. 
            return 2020 - MovieNum;
        }


    }
}

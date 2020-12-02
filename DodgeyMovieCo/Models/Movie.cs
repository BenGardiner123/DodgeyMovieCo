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



        public int GetAge(int MovieNum)
        {
            return 2020 - this.ReleaseYear;
            //returns how old the movie is from the current year as an int
        }


    }
}

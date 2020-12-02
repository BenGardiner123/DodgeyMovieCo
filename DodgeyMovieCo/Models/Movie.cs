using System;
using System.Collections.Generic;
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

        public int NumActors(int MovieNum) {
            NumActorsResponseEnvelope numAct = new NumActorsResponseEnvelope();

            string ActorsCount = "SELECT M.MOVIENO, COUNT(C.ACTORNO)" +
                             "FROM MOVIE M" +
                             "INNER JOIN CASTING C " +
                             "ON C.MOVIENO = M.MOVIENO" +
                             "INNER JOIN ACTOR A " +
                             "ON C.ACTORNO = A.ACTORNO" +
                             "WHERE M.MOVIENO = @MOVIENUM";

            // create connection and command
            SqlConnection connecting = new SqlConnection(connectionString);

            SqlCommand getActorsCmd = new SqlCommand(ActorsCount, connecting);
            getGameCmd.Parameters.Add("@MOVIENUM", SqlDbType.VarChar, 100).Value = MovieNum;

            try
            {
                connecting.Open();

                using (SqlDataReader reader = getActorsCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // ORM - Object Relation Mapping
                        numAct.numberAct.Add(
                            new NumActorsResponseModel() { MovieNo = (int)reader[0], NumActors = (int)reader[1] });
                    }
                    reader.Close();
                }

                connecting.Open();
            }
            catch (SqlException ex)
            {
                throw new ApplicationException($"Some sql error happened + {ex}");
            }

            return 2020 - numAct.numberAct.NumActors;

        }



        public int GetAge(int MovieNum)
        {
            //returns how old the movie is from the current year as an int
            // so now i need to return the eladboard view into something then return that to angualr
            // not sure if i combine the two here or just use the SQLdataclient. 

        }


    }
}

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
            //returns the number of actors cast in the movie as an int
            int output = 0;
            return output;
        }
        
        public int GetAge(int MovieNum) {
            //returns how old the movie is from the current year as an int
            // so now i need to return the eladboard view into something then return that to angualr
            // not sure if i combine the two here or just use the SQLdataclient. 
            NumActorsResponseEnvelope numAct = new NumActorsResponseEnvelope();

            string leadbrd = "Select * from MovieActorTotals ";


            // create connection and command
            SqlConnection connecting = new SqlConnection(connectionString);

            SqlCommand leadCmd = new SqlCommand(leadbrd, connecting);

            try
            {
                connecting.Open();

                using (SqlDataReader reader = leadCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // ORM - Object Relation Mapping
                        numAct.numberAct.Add(
                            new NumActorsResponseModel() { Title = reader[0].ToString(), MovieNo = (int)reader[1], NumActors = (int)reader[2] });
                    }
                    reader.Close();
                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException($"Some sql error happened + {ex}");
            }

            return numAct.numberAct;
            int output = 0;
            return output;
        }
        




    }
}

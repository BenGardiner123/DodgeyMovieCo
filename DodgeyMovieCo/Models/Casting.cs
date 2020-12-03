using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DodgeyMovieCo.Models
{
    public class Casting
    {
        public int CastID { get; set; }
        public int ActorNo { get; set; }
        public int MoveieNo { get; set; }

        public void getAllCastings(string connectionString)
        {
            CastingResponseModelEnvelope castingResults = new CastingResponseModelEnvelope();

            string query1 = "select * from Casting";

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
                        castingResults.CastingList.Add(
                            // major problem here was that float in SQL and float in c# are different - so was throwing a casting error - winratio had to be cast as a "single"
                            new Casting()
                            {
                                CastID = Convert.ToInt32(reader[0]),
                                ActorNo = Convert.ToInt32(reader[1]),
                                MoveieNo = Convert.ToInt32(reader[2])

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

            staticCastingHolder = castingResults.CastingList.ToList();

            return movie1.Movies;

        }






















    }

   
   
}

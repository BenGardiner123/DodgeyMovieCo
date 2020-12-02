using DodgeyMovieCo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DodgeyMovieCo
{
    public class Actor
    {
       
        public int ActorNo { get; set; }
        public string FullName { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }

        public Actor()
        {

        }

        public string setFullName(string connectionString, string fullname)
        {
            ActorResponseModel actorResponse = new ActorResponseModel();
            Movie m1 = new Movie();

            string setName = "SELECT M.MOVIENO, M.TITLE, M.RELYEAR, M.RUNTIME " +
                               "FROM MOVIE M " +
                               "INNER JOIN CASTING C " +
                               "ON C.MOVIENO = M.MOVIENO " +
                               "INNER JOIN ACTOR A " +
                               "ON C.ACTORNO = A.ACTORNO " +
                               $"WHERE REPLACE (A.FULLNAME, '-', '') = '{fullname}'";

            // create connection and command
            SqlConnection connecting = new SqlConnection(connectionString);
            SqlCommand setActorFullname = new SqlCommand(setName, connecting);

            try
            {
                connecting.Open();

                using (SqlDataReader reader = setActorFullname.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // ORM - Object Relation Mapping
                        actorResponse.Actors.Add(
                                             new Actor()
                                             {
                                                 ActorNo = Convert.ToInt32(reader[0]),
                                                 FullName = reader[1].ToString(),
                                                 GivenName = reader[2].ToString(),
                                                 Surname = reader[3].ToString()
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

            

            return actorResponse.Actors;


        }
    }

    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DodgeyMovieCo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {

      // PUT api/<MovieController>/DeppJohnny
      [Route("ChangeActorName")]
      [HttpPut]
      public ActionResult<Actor> Put([FromBody] UpdateActorNameRequest updateActorName)
      {
          //Provide a way to change an actor’s surname and fullname, found by givenname and surname. 
          //New surname to obtained via user input.Change must be reflected in the DB.
          ActorResponseModel actorResponse = new ActorResponseModel();


          string setName = "UPDATE ACTOR A " +
                           $"SET A.SURNAME = {updateActorName.NewSurname} " +
                           $"SET A.FULLNAME = A.GIVENNAME + ' ' + '{updateActorName.NewSurname}' " +
                           $"WHERE A.GIVENNAME = {updateActorName.GivenName} AND A.SURNAME = {updateActorName.Surname}" +
                           " GO " + 
                           "SELECT * FROM ACTOR " +
                           $"WHERE A.GIVENNAME = { updateActorName.GivenName} AND A.SURNAME = { updateActorName.Surname} ";



          // create connection and command
          SqlConnection connecting = new SqlConnection(connectionString);
          SqlCommand setActorNameUsingSurnameAndFullname = new SqlCommand(setName, connecting);

          try
          {
              connecting.Open();

              using (SqlDataReader reader = setActorNameUsingSurnameAndFullname.ExecuteReader())
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



          return Ok(actorResponse.Actors);


      }

    }
}

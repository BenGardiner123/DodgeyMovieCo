using System;
using System.Collections.Generic;
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

        public string setFullName(string givenName, string surname)
        {
            //sets the fullname of the actor which is the givenname and surname with a space in between
            string output = "";
            return output;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DodgeyMovieCo.Models
{
    public class UpdateActorNameRequest
    {
        public string NewSurname { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
      
    }
}

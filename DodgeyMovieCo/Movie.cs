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
            int output = 0;
            return output;
        }
        




    }
}

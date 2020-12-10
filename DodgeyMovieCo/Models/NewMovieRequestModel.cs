using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DodgeyMovieCo.Models
{
    public class NewMovieRequestModel
    {
        public int MovieNum { get; set; }
        public string Title { get; set; }
        public short ReleaseYear { get; set; }
        public short RunTime { get; set; }
    }
}

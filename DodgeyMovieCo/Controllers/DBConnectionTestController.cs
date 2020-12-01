using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


namespace DodgeyMovieCo.Controllers
{
     [ApiController]
    [Route("[controller]")]

    public class DBConnectionTestController : ControllerBase
    {
       
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            
        }

        


    }
}
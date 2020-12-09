using DodgeyMovieCo.MovieClassLb;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DodgeyMovieCo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExceptionController : ControllerBase
    {
        //will need to instntitate a new class of dblayer here and for every controller -  
        public DatabaseLayer MydatabaseLayer;

        public ExceptionController(DatabaseLayer databaseLayer)
        {
            this.MydatabaseLayer = databaseLayer;
        }

       
        [HttpGet]
        public ActionResult<string> attemptDbConnectThenRedirect()
        {

            string result = MydatabaseLayer.dbRedirect();

            return Ok(result);

        }



       



    }
}

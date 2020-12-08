using DodgeyMovieCo.MovieClassLb;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DodgeyMovieCo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExceptionController : ControllerBase
    {
        //will need to instntitate a new class of dblayer here and for every controller -  
        private DatabaseLayer _databaseLayer;
        public ExceptionController(DatabaseLayer databaseLayer)
        {
            this._databaseLayer = databaseLayer;
        }

       
        [HttpGet]
        public ActionResult<string> attemptDbConnectThenRedirect()
        {

            string result = _databaseLayer.dbRedirect();

            return Ok(result);

        

        }



       



    }
}

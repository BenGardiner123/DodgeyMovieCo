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
        //will need to instntitate a new class of dblayer here and then call the db with the fake details - then redirect
        private DatabaseLayer _databaseLayer;
        public ExceptionController(DatabaseLayer databaseLayer)
        {
            this._databaseLayer = databaseLayer;
        }

        []
    }
}

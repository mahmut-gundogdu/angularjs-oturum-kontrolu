using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AngularAuth.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class Default2Controller : ApiController
    {
        [Authorize]
        public string[] Get()
        {

            return new string[3] { "AT", "AVRAT", "Silah" };
        }
    }
}

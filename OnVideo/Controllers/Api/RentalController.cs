using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnVideo.Dtos;

namespace OnVideo.Controllers.Api
{
    public class RentalController : ApiController
    {
        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRental)
        {
            throw new NotImplementedException();
        }
    }
}

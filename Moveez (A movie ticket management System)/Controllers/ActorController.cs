using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Moveez__A_movie_ticket_management_System_.Controllers
{
    
    public class ActorController : ApiController
    {

        [HttpGet]
        [Route("api/Actors")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = ActorService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }


    }

}

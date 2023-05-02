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
    [RoutePrefix("api/cinemahalls")]
    public class CinemahallController : ApiController
    {
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAllCinemahalls()
        {
            try
            {
                var cinemahalls = CinemahallService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Success", Data = cinemahalls });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var cinemahall = CinemahallService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Success", Data = cinemahall });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(CinemahallDTO cinemahall)
        {
            try
            {
                var res = CinemahallService.Create(cinemahall);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", Data = cinemahall });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Inserted", Data = cinemahall });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = cinemahall });
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public HttpResponseMessage Update(int id, CinemahallDTO cinemahall)
        {
            try
            {
                var res = CinemahallService.Update(id, cinemahall);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated", Data = cinemahall });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Updated", Data = cinemahall });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = cinemahall });
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var res = CinemahallService.Delete(id);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Deleted" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Deleted" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
    }
}
using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Moveez__A_movie_ticket_management_System_.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        public UserController()
        {

        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            try
            {
                var users = UserService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Success", Data = users });
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
                var user = UserService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Success", Data = user });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(UserDTO user)
        {
            try
            {
                var res = UserService.Create(user);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", Data = user });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Inserted", Data = user });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = user });
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public HttpResponseMessage Update(int id, UserDTO user)
        {
            try
            {
                var res = UserService.Update(id, user);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated", Data = user });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Updated" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var res = UserService.Delete(id);
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

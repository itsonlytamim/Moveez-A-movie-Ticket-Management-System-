using BLL.DTOs;
using BLL.Services;
using Moveez__A_movie_ticket_management_System_.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Moveez__A_movie_ticket_management_System_.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        public UserController()
        {

        }
        [Logged]
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
        [Route("get/{tokenId}")]
        public HttpResponseMessage Get(int tokenId)
        {
            try
            {
                // Check if the token is authorized and belongs to the user
                if (!AuthService.IsAuthorized(tokenId))
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, new { Msg = "Unauthorized" });
                }

                // Get the user details
                int userId = AuthService.GetUserId(tokenId);
                var user = UserService.Get(userId);

                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Success", Data = user });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        //[httpget]
        //[route("{id}")]
        //public httpresponsemessage get(int id)
        //{
        //    try
        //    {
        //        var user = userservice.get(id);
        //        return request.createresponse(httpstatuscode.ok, new { msg = "success", data = user });
        //    }
        //    catch (exception ex)
        //    {
        //        return request.createresponse(httpstatuscode.internalservererror, new { msg = ex.message });
        //    }
        //}

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
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Could not Create User, Error" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = ex.Message, Data = user });
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

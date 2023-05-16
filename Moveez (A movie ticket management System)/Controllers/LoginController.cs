using BLL.Services;
using Moveez__A_movie_ticket_management_System_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Moveez__A_movie_ticket_management_System_.Controllers
{
    public class LoginController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/login")]

        public HttpResponseMessage Login(LoginModel login)
        {


            var res = AuthService.Authenticate(login.Email, login.Password);
            if (res != null)
            {
                var tokenId = res.Id;

                if (AuthService.IsAdmin(res.Id))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        Status = "Success",
                        Message = "Login successful",
                        Data = tokenId,
                        RedirectUrl = "C:\\Users\\Asus\\Desktop\\Frontend\\admin.html"
                    });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        Status = "Success",
                        Message = "Login successful",
                        Data = tokenId,
                        RedirectUrl = "C:\\Users\\Asus\\Desktop\\Frontend\\homeuser.html"
                    });
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new
                {
                    Status = "Error",
                    Message = "Invalid email or password"
                });
            }


        }
        [HttpGet]
        [Route("{id}/login-activity")]
        public HttpResponseMessage GetLoginActivity(int id)
        {
            try
            {
                var tokens = TokenService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Success", Data = tokens });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

    }
}


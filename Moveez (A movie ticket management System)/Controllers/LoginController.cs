﻿using BLL.Services;
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
        [EnableCors("*", "*", "*")]
        [HttpPost]
        [Route("api/login")]

        public HttpResponseMessage Login(LoginModel login)
        {


            var res = AuthService.Authenticate(login.Email, login.Password);
            if (res)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    Status = "Success",
                    Message = "Login successful",
                    Data = res
                });
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
    }
}



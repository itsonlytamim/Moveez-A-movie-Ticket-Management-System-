using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Moveez__A_movie_ticket_management_System_.Auth
{
    public class Logged : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers.Authorization;
            if (token == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, new { Msg = "No token supplied" });
            }
            else if (!int.TryParse(token.ToString(), out int tokenId))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, new { Msg = "Invalid token format" });
            }
            else if (!AuthService.IsAuthorized(tokenId))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, new { Msg = "Supplied token is invalid or expired" });
            }
            base.OnAuthorization(actionContext);
        }
    }

}
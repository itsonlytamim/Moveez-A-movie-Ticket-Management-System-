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

    [RoutePrefix("api/orders")]
    public class OrderController : ApiController
    {

        public OrderController()
        {

        }
        // [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            try
            {
                var orders = OrderService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Success", Data = orders });
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
                var order = OrderService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Success", Data = order });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(OrderDTO order)
        {
            try
            {
                var res = OrderService.Create(order);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", Data = order });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Inserted", Data = order });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = order });
            }
        }
        [HttpPut]
        [Route("update/{id}")]
        public HttpResponseMessage Update(int id, OrderDTO order)
        {
            try
            {
                var orderd = OrderService.Get(id);
                var userId = orderd.UserId;
                if (!UserService.IsAdmin(userId))
                {
                    return Request.CreateResponse(HttpStatusCode.Forbidden, new { Msg = "You do not have permission to perform this action." });
                }

                var res = OrderService.Update(id, order);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated", Data = order });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Updated", Data = order });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = order });
            }
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var orderd = OrderService.Get(id);
                var userId = orderd.UserId;
                if (!UserService.IsAdmin(userId))
                {
                    return Request.CreateResponse(HttpStatusCode.Forbidden, new { Msg = "You do not have permission to perform this action." });
                }

                var res = OrderService.Delete(id);
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
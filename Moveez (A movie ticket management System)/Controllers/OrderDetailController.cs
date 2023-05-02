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
    [RoutePrefix("api/orderdetail")]
    public class OrderDetailController : ApiController
    {

        public OrderDetailController()
        {

        }
        // [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            try
            {
                var orderdetails = OrderDetailService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Success", Data = orderdetails });
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
                var orderdetails = OrderDetailService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Success", Data = orderdetails });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(OrderDetailDTO orderdetails)
        {
            try
            {
                var res = OrderDetailService.Create(orderdetails);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", Data = orderdetails });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Inserted", Data = orderdetails });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = orderdetails });
            }
        }
        [HttpPut]
        [Route("update/{id}")]
        public HttpResponseMessage Update(int id, OrderDetailDTO orderdetails)
        {
            try
            {
                var orderd = OrderDetailService.Get(id);
                var ordId = orderd.OrderId;
                var chk = OrderService.Get(ordId);
                var userId = chk.UserId;
                if (!UserService.IsAdmin(userId))
                {
                    return Request.CreateResponse(HttpStatusCode.Forbidden, new { Msg = "You do not have permission to perform this action." });
                }

                var res = OrderDetailService.Update(id, orderdetails);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated", Data = orderdetails });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Updated", Data = orderdetails });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = orderdetails });
            }
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var orderd = OrderDetailService.Get(id);
                var ordId = orderd.OrderId;
                var chk = OrderService.Get(ordId);
                var userId = chk.UserId;
                if (!UserService.IsAdmin(userId))
                {
                    return Request.CreateResponse(HttpStatusCode.Forbidden, new { Msg = "You do not have permission to perform this action." });
                }
                var res = OrderDetailService.Delete(id);
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
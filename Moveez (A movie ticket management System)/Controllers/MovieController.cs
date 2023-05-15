using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Moveez__A_movie_ticket_management_System_.Controllers
{



    [EnableCors(origins: "*", headers: "*", methods: "*")]

    [RoutePrefix("api/movies")]
        public class MovieController : ApiController
        {
        public MovieController()
        {

        }

            [HttpGet]
            [Route("")]
            public HttpResponseMessage Get()
            {
                try
                {
                    var movies = MovieService.Get();
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Success", Data = movies });
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
                    var movie = MovieService.Get(id);
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Success", Data = movie });
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
                }
            }

            [HttpPost]
            [Route("add")]
            public HttpResponseMessage Add(MovieDTO movie)
            {
                try
                {
                    var res = MovieService.Create(movie);
                    if (res)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", Data = movie });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Inserted", Data = movie });
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = movie });
                }
            }

            [HttpPut]
            [Route("update/{id}")]
            public HttpResponseMessage Update(int id, MovieDTO movie)
            {
                try
                {
                    var res = MovieService.Update(id,movie);
                    if (res)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated", Data = movie });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Updated", Data = movie });
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = movie });
                }
            }

            [HttpDelete]
            [Route("delete/{id}")]
            public HttpResponseMessage Delete(int id)
            {
                try
                {
                    var res = MovieService.Delete(id);
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


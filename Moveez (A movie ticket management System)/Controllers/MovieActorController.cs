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

    [RoutePrefix("api/movie-actors")]
    public class MovieActorController : ApiController
    {
        public MovieActorController()
         {

         }

         [HttpGet]
         [Route("")]
         public HttpResponseMessage Get()
         {
             try
             {
                 var movieActors = MovieActorService.Get();
                 return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Success", Data = movieActors });
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
                 var movieActor = MovieActorService.Get(id);
                 return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Success", Data = movieActor });
             }
             catch (Exception ex)
             {
                 return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
             }
         }

         [HttpPost]
         [Route("add")]
         public HttpResponseMessage Add(MovieActorDTO movieActor)
         {
             try
             {
                 var res = MovieActorService.Create(movieActor);
                 if (res)
                 {
                     return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", Data = movieActor });
                 }
                 else
                 {
                     return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Inserted", Data = movieActor });
                 }
             }
             catch (Exception ex)
             {
                 return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = movieActor });
             }
         }

         [HttpPut]
         [Route("update/{id}")]
         public HttpResponseMessage Update(int id, MovieActorDTO movieActor)
         {
             try
             {
                 var res = MovieActorService.Update(id, movieActor);
                 if (res)
                 {
                     return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated", Data = movieActor });
                 }
                 else
                 {
                     return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Updated", Data = movieActor });
                 }
             }
             catch (Exception ex)
             {
                 return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = movieActor });
             }
         }

         [HttpDelete]
         [Route("delete/{id}")]
         public HttpResponseMessage Delete(int id)
         {
             try
             {
                 var res = MovieActorService.Delete(id);
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

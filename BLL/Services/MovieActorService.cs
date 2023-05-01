using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;

namespace BLL.Services
{
    public class MovieActorService
    {
        public static List<MovieActorDTO> Get()
        {
            var data = DataAccessFactory.MovieActorData().Get();
            return Convert(data);
        }

        public static MovieActorDTO Get(int id)
        {
            return Convert(DataAccessFactory.MovieActorData().Get(id));
        }

        public static bool Create(MovieActorDTO movieActor)
        {
            var data = Convert(movieActor);
            var res = DataAccessFactory.MovieActorData().Insert(data);

            if (res != null) return true;
            return false;
        }

        public static bool Update(MovieActorDTO movieActor)
        {
            var data = Convert(movieActor);
            var res = DataAccessFactory.MovieActorData().Update(data);

            if (res != null) return true;
            return false;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.MovieActorData().Delete(id);
        }

        static List<MovieActorDTO> Convert(List<MovieActor> movieActors)
        {
            var data = new List<MovieActorDTO>();
            foreach (var movieActor in movieActors)
            {
                data.Add(Convert(movieActor));
            }
            return data;
        }

        static MovieActor Convert(MovieActorDTO movieActor)
        {
            return new MovieActor()
            {
                Id = movieActor.Id,
                MovieId = movieActor.MovieId,
                ActorId = movieActor.ActorId
            };
        }

        static MovieActorDTO Convert(MovieActor movieActor)
        {
            return new MovieActorDTO()
            {
                Id = movieActor.Id,
                MovieId = movieActor.MovieId,
                ActorId = movieActor.ActorId
            };
        }
    }
}


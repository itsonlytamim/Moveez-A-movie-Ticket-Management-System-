using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class MovieActorRepo : Repo, IRepo<MovieActor, int, bool>
    {


        public List<MovieActor> Get()
        {
            return db.MovieActors.ToList();
        }

        public MovieActor Get(int id)
        {
            return db.MovieActors.Find(id);
        }

        public bool Insert(MovieActor obj)
        {
            db.MovieActors.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(MovieActor obj)
        {
            var movieActor = db.MovieActors.Find(obj.Id);
            if (movieActor != null)
            {
                movieActor.MovieId = obj.MovieId;
                movieActor.ActorId = obj.ActorId;
                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public bool Delete(int id)
        {
            var movieActor = db.MovieActors.Find(id);
            if (movieActor != null)
            {
                db.MovieActors.Remove(movieActor);
                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
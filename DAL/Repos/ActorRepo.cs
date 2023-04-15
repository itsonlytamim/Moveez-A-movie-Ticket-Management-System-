using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repos
{
    internal class ActorRepo : Repo, IRepo<Actor, int, bool>
    {
        public List<Actor> Get()
        {
            return db.Actors.ToList();
        }

        public Actor Get(int id)
        {
            return db.Actors.Find(id);
        }

        public bool Insert(Actor obj)
        {
            db.Actors.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(Actor obj)
        {
            var actor = db.Actors.Find(obj.Id);
            if (actor != null)
            {
                actor.Name = obj.Name;
                actor.DateOfBirth = obj.DateOfBirth;
                actor.Gender = obj.Gender;
                actor.Nationality = obj.Nationality;
                actor.Biography = obj.Biography;
                actor.ImageUrl = obj.ImageUrl;
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
            var actor = db.Actors.Find(id);
            if (actor != null)
            {
                db.Actors.Remove(actor);
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

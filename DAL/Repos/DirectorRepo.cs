using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class DirectorRepo : Repo, IRepo<Director, int, bool>
    {
        public List<Director> Get()
        {
            return db.Directors.ToList();
        }

        public Director Get(int id)
        {
            return db.Directors.Find(id);
        }

        public bool Insert(Director obj)
        {

            db.Directors.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(Director obj)
        {
           
                var director = db.Directors.Find(obj.Id);
                if (director != null)
                {
                    director.Name = obj.Name;
                    director.DateOfBirth = obj.DateOfBirth;
                    director.Gender = obj.Gender;
                    director.Nationality = obj.Nationality;
                    director.Biography = obj.Biography;
                    director.ImageUrl = obj.ImageUrl;
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
            var director = db.Directors.FirstOrDefault(d => d.Id == id);
            if (director != null)
            {
                db.Directors.Remove(director);
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

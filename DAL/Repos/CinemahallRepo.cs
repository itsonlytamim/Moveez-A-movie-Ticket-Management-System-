using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CinemahallRepo : Repo, IRepo<Cinemahall, int, bool>
    {
        public List<Cinemahall> Get()
        {
            return db.Cinemahalls.ToList();
        }

        public Cinemahall Get(int id)
        {
            return db.Cinemahalls.Find(id);
        }

        public bool Insert(Cinemahall obj)
        {
            
            db.Cinemahalls.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Update(Cinemahall obj)
        {

            var existingCinemahall = db.Cinemahalls.Find(obj.Id);
            if (existingCinemahall != null)
            {
                existingCinemahall.Name = obj.Name;
                existingCinemahall.Description = obj.Description;
                existingCinemahall.SeatNo = obj.SeatNo;
                existingCinemahall.Capacity = obj.Capacity;
                existingCinemahall.Location = obj.Location;
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

            var existingCinemahall = db.Cinemahalls.Find(id);
            if (existingCinemahall != null)
            {
                db.Cinemahalls.Remove(existingCinemahall);
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

using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class NotificationRepo : Repo, IRepo<Notification, int, bool>
    {
        public NotificationRepo() : base()
        {
        }

        public List<Notification> Get()
        {
            return db.Notifications.ToList();
        }

        public Notification Get(int id)
        {
            return db.Notifications.Find(id);
        }

        public bool Insert(Notification obj)
        {
            db.Notifications.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(Notification obj)
        {
            var notification = db.Notifications.Find(obj.Id);
            if (notification != null)
            {
                notification.Message = obj.Message;
                notification.UserId = obj.UserId;
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
            var notification = db.Notifications.Find(id);
            if (notification != null)
            {
                db.Notifications.Remove(notification);
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
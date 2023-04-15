using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TicketRepo : Repo, IRepo<Ticket, int, bool>
    {
        public List<Ticket> Get()
        {
            return db.Tickets.ToList();
        }

        public Ticket Get(int id)
        {
            return db.Tickets.Find(id);
        }

        public bool Insert(Ticket obj)
        {
            db.Tickets.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(Ticket obj)
        {
            var ticket = db.Tickets.Find(obj.Id);
            if (ticket != null)
            {
                ticket.Type = obj.Type;
                ticket.Price = obj.Price;
                ticket.MovieId = obj.MovieId;
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
            var ticket = db.Tickets.Find(id);
            if (ticket != null)
            {
                db.Tickets.Remove(ticket);
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

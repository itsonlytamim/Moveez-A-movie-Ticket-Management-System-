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
    public class TicketService
    {
        public static List<TicketDTO> Get()
        {
            var data = DataAccessFactory.TicketData().Get();
            return Convert(data);
        }

        public static TicketDTO Get(int id)
        {
            var data = DataAccessFactory.TicketData().Get(id);
            return Convert(data);
        }

        public static bool Create(TicketDTO ticket)
        {
            var data = Convert(ticket);
            var res = DataAccessFactory.TicketData().Insert(data);
            if (res = true)
            {
                return true;
            }
            return false;
        }

        public static bool Update(TicketDTO ticket)
        {
            var data = Convert(ticket);
            var res = DataAccessFactory.TicketData().Update(data);
            if (res = true)
            {
                return true;
            }
            return false;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.TicketData().Delete(id);
        }

        static List<TicketDTO> Convert(List<Ticket> tickets)
        {
            var data = new List<TicketDTO>();
            foreach (var ticket in tickets)
            {
                data.Add(Convert(ticket));
            }
            return data;
        }

        static TicketDTO Convert(Ticket ticket)
        {
            return new TicketDTO()
            {
                Id = ticket.Id,
                Type = ticket.Type,
                Price = ticket.Price,
                MovieId = ticket.MovieId
            };
        }

        static Ticket Convert(TicketDTO ticket)
        {
            return new Ticket()
            {
                Id = ticket.Id,
                Type = ticket.Type,
                Price = ticket.Price,
                MovieId = ticket.MovieId
            };
        }
    }
}
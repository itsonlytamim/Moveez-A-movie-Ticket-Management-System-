using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Actor, int, bool> ActorData()
        {
            return new ActorRepo();
        }
        public static IRepo<Movie, int, bool> MovieData()
        {
            return new MovieRepo();
        }

        public static IRepo<Director, int, bool> DirectorData()
        {
            return new DirectorRepo();
        }

        public static IRepo<MovieActor, int, bool> MovieActorData()
        {
            return new MovieActorRepo();
        }

        public static IRepo<Ticket, int, bool> TicketData()
        {
            return new TicketRepo();
        }

        public static IRepo<Cinemahall, int, bool> CinemahallData()
        {
            return new CinemahallRepo();
        }

        public static IRepo<User, int, bool> UserData()
        {
            return new UserRepo();
        }

        public static IRepo<Order, int, bool> OrderData()
        {
            return new OrderRepo();
        }

        public static IRepo<OrderDetail, int, bool> OrderDetailData()
        {
            return new OrderDetailRepo();
        }

        public static IRepo<MovieActor, int, bool> MovieactorData()
        {
            return new MovieActorRepo();
        }

    }
}

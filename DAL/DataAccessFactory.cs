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
        public static IRepo<User, int, bool> UserData()
        {
            return new UserRepo();
        }

    }
}

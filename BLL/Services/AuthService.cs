using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        public static bool Authenticate(string email, string password)
        {
            return DataAccessFactory.AuthData().Authenticate(email, password);
        }

        public static string Authenticate(string email, string password)
        {
            var user = DataAccessFactory.AuthData().Authenticate(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                // create a new token for the user
                var token = DataAccessFactory.UserData().CreateToken(user.Id);

                return token;
            }

            return null;
        }

    }
}

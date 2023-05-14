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
      

        public User Authenticate(string email, string password)
        {
            var user = DataAccessFactory.AuthData().Authenticate(email , password);

            if (user)
            {
                // create a new token for the user

                var token = DataAccessFactory.TokenData().Insert();

                return token;
            }

            return null;
        }

    }
}

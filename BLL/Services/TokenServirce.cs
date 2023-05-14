using DAL;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TokenService 
    {

        public TokenService()
        {
        }

        public bool CreateToken(int userId)
        {
            var token = Guid.NewGuid().ToString("n");
            var createdAt = DateTime.UtcNow;
            var expiresAt = createdAt.AddDays(7); // token expires in 7 days

            var newToken = new Token
            {
                UserId = userId,
                TokenString = token,
                CreatedAt = createdAt,
                ExpiresAt = expiresAt
            };

           var res= DataAccessFactory.TokenData().Insert(newToken);

            return res = true;
        }

        public Token Get(int id)
        {
            return Convert(DataAccessFactory.TokenData().Get(id));
        }

        public bool IsTokenValid(string tokenString)
        {
            var token = GetByTokenString(tokenString);
            if (token != null && token.ExpiresAt > DateTime.UtcNow)
            {
                token.ExpiresAt = token.ExpiresAt.AddDays(7);
                _repo.Update(token);
                return true;
            }
            return false;
        }

        public bool DeleteToken(string tokenString)
        {
            var token = GetByTokenString(tokenString);
            if (token != null)
            {
                _repo.Delete(token.Id);
                return true;
            }
            return false;
        }
    }

}

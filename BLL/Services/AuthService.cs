using AutoMapper;
using BLL.DTOs;
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
        public static TokenDto Authenticate(string email, string password)
        {
            var user = DataAccessFactory.AuthData().Authenticate(email, password);

            if (!user) return null;


            var existingUser = DataAccessFactory.UserData().Get().FirstOrDefault(u => u.Email == email);

            var token = new Token
            {
                UserId = existingUser.Id,
                TokenString = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                ExpiresAt = null
            };
            var success = DataAccessFactory.TokenData().Insert(token);
            if (!success) return null;

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Token, TokenDto>();
            });
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<TokenDto>(token);
        }
        public static int GetUserId(int tokenId)
        {
            var token = DataAccessFactory.TokenData().Get(tokenId);
            if (token != null)
            {
                return token.UserId;
            }
            return -1;
        }
        public static bool IsAuthorized(int tokenId)
        {
            var token = DataAccessFactory.TokenData().Get(tokenId);
            return token != null && token.ExpiresAt == null;
        }

        public static bool IsAdmin(int tokenId)
        {
            var token = DataAccessFactory.TokenData().Get(tokenId);
            return IsAuthorized(tokenId) && token.User.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase);
        }

        public static bool Logout(int tokenId)
        {
            var token = DataAccessFactory.TokenData().Get(tokenId);
            if (token != null)
            {
                token.ExpiresAt = DateTime.Now;
                return DataAccessFactory.TokenData().Update(token);
            }
            return false;
        }


    }

}

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
    public class TokenService
    {
        public static List<TokenDto> Get()
        {
            var tokens = DataAccessFactory.TokenData().Get();
            var mapperConfig = new MapperConfiguration(cfg => cfg.CreateMap<Token, TokenDto>());
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<List<TokenDto>>(tokens);
        }

        public static TokenDto Get(int id)
        {
            var token = DataAccessFactory.TokenData().Get(id);
            if (token == null)
            {
                return null;
            }

            var mapperConfig = new MapperConfiguration(cfg => cfg.CreateMap<Token, TokenDto>());
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<TokenDto>(token);
        }

        public static bool Update(TokenDto token)
        {
            var existingToken = DataAccessFactory.TokenData().Get(token.Id);
            if (existingToken == null)
            {
                return false;
            }

            existingToken.UserId = token.UserId;
            existingToken.TokenString = token.TokenString;
            existingToken.CreatedAt = token.CreatedAt;
            existingToken.ExpiresAt = token.ExpiresAt;

            return DataAccessFactory.TokenData().Update(existingToken);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.TokenData().Delete(id);
        }
    }

}
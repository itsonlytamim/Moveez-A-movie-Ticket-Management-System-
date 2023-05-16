using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CartDetailService
    {
        public static List<CartDetailDTO> Get()
        {
            var data = DataAccessFactory.CartDetailData().Get();
            return data.Select(Convert).ToList();
        }

        public static CartDetailDTO Get(int id)
        {
            return Convert(DataAccessFactory.CartDetailData().Get(id));
        }

        public static bool Create(CartDetailDTO cartDetail)
        {
            var data = Convert(cartDetail);
            var res = DataAccessFactory.CartDetailData().Insert(data);

            return res = true;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.CartDetailData().Delete(id);
        }

        public static bool Update(int id, CartDetailDTO cartDetail)
        {
            var extCartDetail = DataAccessFactory.CartDetailData().Get(id);
            if (extCartDetail == null) return false;

            extCartDetail.Id = extCartDetail.Id;
            extCartDetail.Quantity = cartDetail.Quantity;
            extCartDetail.Price = cartDetail.Price;
            extCartDetail.MovieId = cartDetail.MovieId;
            extCartDetail.CartId = cartDetail.CartId;

            var res = DataAccessFactory.CartDetailData().Update(extCartDetail);

            return res = true;
        }

        private static CartDetailDTO Convert(CartDetail cartDetail)
        {
            return new CartDetailDTO
            {
                Id = cartDetail.Id,
                Quantity = cartDetail.Quantity,
                Price = cartDetail.Price,
                MovieId = cartDetail.MovieId,
                CartId = cartDetail.CartId,
            };
        }

        private static CartDetail Convert(CartDetailDTO cartDetail)
        {
            return new CartDetail
            {
                Id = cartDetail.Id,
                Quantity = cartDetail.Quantity,
                Price = cartDetail.Price,
                MovieId = cartDetail.MovieId,
                CartId = cartDetail.CartId,
            };
        }


    }
}
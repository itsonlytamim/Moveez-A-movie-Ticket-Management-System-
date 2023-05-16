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
    public class CartService
    {
        public static List<CartDTO> Get()
        {
            var data = DataAccessFactory.CartData().Get();
            return data.Select(Convert).ToList();
        }

        public static CartDTO Get(int id)
        {
            return Convert(DataAccessFactory.CartData().Get(id));
        }

        public static bool Create(CartDTO cart)
        {
            var data = Convert(cart);
            var res = DataAccessFactory.CartData().Insert(data);

            return res = true;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.CartData().Delete(id);
        }

        public static bool Update(int id, CartDTO cart)
        {
            var extCart = DataAccessFactory.CartData().Get(id);
            if (extCart == null) return false;

            extCart.Id = extCart.Id;
            extCart.UserId = extCart.UserId;

            var res = DataAccessFactory.CartData().Update(extCart);

            return res = true;
        }

        private static CartDTO Convert(Cart cart)
        {
            return new CartDTO
            {
                Id = cart.Id,
                UserId = cart.UserId,
            };
        }

        private static Cart Convert(CartDTO cart)
        {
            return new Cart
            {
                Id = cart.Id,
                UserId = cart.UserId,
            };
        }
    }

}
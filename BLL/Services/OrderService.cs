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
    public class OrderService
    {
        public static List<OrderDTO> Get()
        {
            var data = DataAccessFactory.OrderData().Get();
            return data.Select(Convert).ToList();
        }

        public static OrderDTO Get(int id)
        {
            return Convert(DataAccessFactory.OrderData().Get(id));
        }

        public static bool Create(OrderDTO order)
        {
            var data = Convert(order);
            var res = DataAccessFactory.OrderData().Insert(data);

            return res = true;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.OrderData().Delete(id);
        }

        public static bool Update(OrderDTO order)
        {
            var data = Convert(order);
            var res = DataAccessFactory.OrderData().Update(data);

            return res = true;
        }

        public static bool Update(int id, OrderDTO order)
        {
            var existingOrder = DataAccessFactory.OrderData().Get(id);
            if (existingOrder == null) return false;

            existingOrder.OrderDate = order.OrderDate;
            existingOrder.UserId = order.UserId;
            var res = DataAccessFactory.OrderData().Update(existingOrder);

            return res = true;
        }

        private static OrderDTO Convert(Order order)
        {
            return new OrderDTO
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                UserId = order.UserId,
            };
        }

        private static Order Convert(OrderDTO order)
        {
            return new Order
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                UserId = order.UserId,
            };
        }
    }

}
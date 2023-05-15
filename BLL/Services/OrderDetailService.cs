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
    public class OrderDetailService
    {
        public static List<OrderDetailDTO> Get()
        {
            var data = DataAccessFactory.OrderDetailData().Get();
            return data.Select(Convert).ToList();
        }

        public static OrderDetailDTO Get(int id)
        {
            return Convert(DataAccessFactory.OrderDetailData().Get(id));
        }

        public static bool Create(OrderDetailDTO orderDetail)
        {
            var data = Convert(orderDetail);
            var res = DataAccessFactory.OrderDetailData().Insert(data);

            return res = true;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.OrderDetailData().Delete(id);
        }

        public static bool Update(OrderDetailDTO orderDetail)
        {
            var data = Convert(orderDetail);
            var res = DataAccessFactory.OrderDetailData().Update(data);

            return res = true;
        }

        public static bool Update(int id, OrderDetailDTO orderDetail)
        {
            var existingOrderDetail = DataAccessFactory.OrderDetailData().Get(id);
            if (existingOrderDetail == null) return false;

            existingOrderDetail.Name = orderDetail.Name;
            existingOrderDetail.Quantity = orderDetail.Quantity;
            existingOrderDetail.Price = orderDetail.Price;
            existingOrderDetail.MovieId = orderDetail.MovieId;
            existingOrderDetail.OrderId = orderDetail.OrderId;

            var res = DataAccessFactory.OrderDetailData().Update(existingOrderDetail);

            return res = true;
        }

        private static OrderDetailDTO Convert(OrderDetail orderDetail)
        {
            return new OrderDetailDTO
            {
                Id = orderDetail.Id,
                Name = orderDetail.Name,
                Quantity = orderDetail.Quantity,
                Price = orderDetail.Price,
                MovieId = orderDetail.MovieId,
                OrderId = orderDetail.OrderId,
            };
        }

        private static OrderDetail Convert(OrderDetailDTO orderDetail)
        {
            return new OrderDetail
            {
                Id = orderDetail.Id,
                Name = orderDetail.Name,
                Quantity = orderDetail.Quantity,
                Price = orderDetail.Price,
                MovieId = orderDetail.MovieId,
                OrderId = orderDetail.OrderId,
            };
        }
    }
}

using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class OrderDetailRepo : Repo, IRepo<OrderDetail, int, bool>
    {

        public List<OrderDetail> Get()
        {
            return db.OrderDetails.ToList();
        }

        public OrderDetail Get(int id)
        {
            return db.OrderDetails.Find(id);
        }

        public bool Insert(OrderDetail obj)
        {
            db.OrderDetails.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(OrderDetail obj)
        {
            var orderDetail = db.OrderDetails.Find(obj.Id);
            if (orderDetail != null)
            {
                orderDetail.Name = obj.Name;
                orderDetail.Quantity = obj.Quantity;
                orderDetail.Price = obj.Price;
                orderDetail.MovieId = obj.MovieId;
                orderDetail.OrderId = obj.OrderId;
                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public bool Delete(int id)
        {
            var orderDetail = db.OrderDetails.Find(id);
            if (orderDetail != null)
            {
                db.OrderDetails.Remove(orderDetail);
                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}

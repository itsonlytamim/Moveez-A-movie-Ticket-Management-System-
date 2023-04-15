using DAL.Interfaces;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class CartDetailRepo : Repo, IRepo<CartDetail, int, bool>
    {
      
        public CartDetail Get(int id)
        {
            return db.CartDetails.Find(id);
        }

        public List<CartDetail> Get()
        {
            return db.CartDetails.ToList();
        }

        public bool Insert(CartDetail obj)
        {
            db.CartDetails.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(CartDetail obj)
        {
            var cartDetail = db.CartDetails.Find(obj.Id);
            if (cartDetail != null)
            {


                cartDetail.Quantity = obj.Quantity;
                cartDetail.Price = obj.Price;
                cartDetail.MovieId = obj.MovieId;
                cartDetail.CartId = obj.CartId;

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
            var cartDetail = db.CartDetails.Find(id);
            if (cartDetail == null)
                return false;

            db.CartDetails.Remove(cartDetail);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}


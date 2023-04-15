using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using DAL.Models;
namespace DAL.Repos
{
    internal class CartRepo : Repo, IRepo<Cart, int, bool>
    {
        public CartRepo() : base() { }

        public List<Cart> Get()
        {
            return db.Carts.ToList();
        }

        public Cart Get(int id)
        {
            return db.Carts.Find(id);
        }

        public bool Insert(Cart obj)
        {
            db.Carts.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(Cart obj)
        {
            var cart = db.Carts.Find(obj.Id);
            if (cart == null) return false;

            cart.UserId = obj.UserId;

            if (db.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var cart = db.Carts.Find(id);
            if (cart == null) return false;

            db.Carts.Remove(cart);
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


using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TokenRepo : Repo, IRepo<Token, int, bool>
    {

        public TokenRepo()
        {
        }

        public bool Insert(Token entity)
        {
            db.Tokens.Add(entity);
            if (db.SaveChanges() > 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var token = db.Tokens.Find(id);
            if (token != null)
            {
                db.Tokens.Remove(token);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Token> Get()
        {
            return db.Tokens.Include(t => t.User).ToList();
        }

        public Token Get(int id)
        {
            return db.Tokens.Include(t => t.User).SingleOrDefault(t => t.Id == id);
        }

        public bool Update(Token entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }
    }
}

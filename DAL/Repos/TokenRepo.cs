using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TokenRepo : Repo, IRepo<Token, int, bool>
    {
        public TokenRepo() : base() { }

        public List<Token> GetAllByUserId(int userId)
        {
            return db.Tokens.Where(t => t.UserId == userId).ToList();
        }

        public Token GetByTokenString(string tokenString)
        {
            return db.Tokens.FirstOrDefault(t => t.TokenString == tokenString);
        }

        public Token Get(int id)
        {
            return db.Tokens.Find(id);
        }

        public bool Insert(Token obj)
        {

            db.Tokens.Add(obj);
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
            var tokens = db.Tokens.Find(id);
            if (tokens != null)
            {
                db.Tokens.Remove(tokens);
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

        public List<Token> Get()
        {
            return db.Tokens.ToList();
        }

        public bool Update(Token obj)
        {
            throw new NotImplementedException();
        }
    }
}



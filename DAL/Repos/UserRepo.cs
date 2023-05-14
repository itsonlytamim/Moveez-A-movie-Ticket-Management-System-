using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, int, bool>, IAuth<bool>, 
    {
        public UserRepo() : base() { }

        public bool Authenticate(string Email, string Password)
        {
            var data = db.Users.FirstOrDefault(u => u.Email.Equals(Email) &&
            u.Password.Equals(Password));
            if (data != null) return true;
            return false;
        }

        public string CreateToken(int userId)
        {
            var token = Guid.NewGuid().ToString("n");
            var createdAt = DateTime.UtcNow;
            var expiresAt = createdAt.AddDays(7); // token expires in 7 days

            var newToken = new Token
            {
                UserId = userId,
                TokenString = token,
                CreatedAt = createdAt,
                ExpiresAt = expiresAt
            };

            db.Tokens.Add(newToken);
            db.SaveChanges();

            return token;
        }

        public List<Token> GetTokens(int userId)
        {
            return DataAccessFactory.TokenData().GetAllByUserId(userId);
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public bool Insert(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(User user)
        {
            var existingUser = db.Users.Find(user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;
                existingUser.Phone = user.Phone;
                existingUser.Address = user.Address;
                existingUser.Photo = user.Photo;
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
            var userToDelete = db.Users.Find(id);
            if (userToDelete != null)
            {
                db.Users.Remove(userToDelete);
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

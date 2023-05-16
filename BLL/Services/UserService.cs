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
    public class UserService
    {
        public static List<UserDTO> Get()
        {
            var data = DataAccessFactory.UserData().Get();
            return data.Select(Convert).ToList();
        }

        public static bool IsAdmin(int Id)
        {
            var user = DataAccessFactory.UserData().Get(Id);

            if (user != null && user.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }
        public static UserDTO Get(int id)
        {
            return Convert(DataAccessFactory.UserData().Get(id));
        }

        public static bool Create(UserDTO user)
        {
            var data = Convert(user);
            var existingUser = DataAccessFactory.UserData().Get().FirstOrDefault(u => u.Email == data.Email);

            if (existingUser != null)
            {
                return false; // User already exists, return false
            }

            var res = DataAccessFactory.UserData().Insert(data);

            return res = true;
        }


        public static bool Delete(int id)
        {
            return DataAccessFactory.UserData().Delete(id);
        }

        public static bool Update(UserDTO user)
        {
            var data = Convert(user);
            var res = DataAccessFactory.UserData().Update(data);

            return res = true;
        }

        public static bool Update(int id, UserDTO user)
        {
            var existingUser = DataAccessFactory.UserData().Get(id);
            if (existingUser == null) return false;

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Phone = user.Phone;
            existingUser.DateOfBirth = user.DateOfBirth;
            existingUser.Gender = user.Gender;
            existingUser.IsVerified = user.IsVerified;
            existingUser.Address = user.Address;
            existingUser.Photo = user.Photo;
            var res = DataAccessFactory.UserData().Update(existingUser);

            return res = true;
        }


        private static UserDTO Convert(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role,
                Phone = user.Phone,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                IsVerified = user.IsVerified,
                Address = user.Address,
                Photo = user.Photo,
            };
        }

        private static User Convert(UserDTO user)
        {
            return new User
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role,
                Phone = user.Phone,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                IsVerified = user.IsVerified,
                Address = user.Address,
                Photo = user.Photo,
            };
        }
    }
}
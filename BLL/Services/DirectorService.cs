using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;

namespace BLL.Services
{
    public class DirectorService
    {
        public static List<DirectorDTO> Get()
        {
            var data = DataAccessFactory.DirectorData().Get();
            return Convert(data);
        }

        public static DirectorDTO Get(int id)
        {
            var data = DataAccessFactory.DirectorData().Get(id);
            return Convert(data);
        }

        public static bool Create(DirectorDTO director)
        {
            var data = Convert(director);
            var res = DataAccessFactory.DirectorData().Insert(data);

            if (res = true) return true;
            return false;
        }


        public static bool Update(int id, DirectorDTO director)
        {
            var existingDirector = DataAccessFactory.DirectorData().Get(id);
            if (existingDirector == null) return false;

            existingDirector.Name = director.Name;
            existingDirector.DateOfBirth = director.DateOfBirth;
            existingDirector.Gender = director.Gender;
            existingDirector.Nationality = director.Nationality;
            existingDirector.Biography = director.Biography;
            existingDirector.ImageUrl = director.ImageUrl;

            var res = DataAccessFactory.DirectorData().Update(existingDirector);

            if (res = true) return true;
            return false;
        }





        public static bool Delete(int id)
        {
            return DataAccessFactory.DirectorData().Delete(id);
        }

        static List<DirectorDTO> Convert(List<Director> directors)
        {
            var data = new List<DirectorDTO>();
            foreach (var dir in directors)
            {
                data.Add(Convert(dir));
            }
            return data;
        }

        static Director Convert(DirectorDTO dir)
        {
            return new Director()
            {
                Id = dir.Id,
                Name = dir.Name,
                DateOfBirth = dir.DateOfBirth,
                Gender = dir.Gender,
                Nationality = dir.Nationality,
                Biography = dir.Biography,
                ImageUrl = dir.ImageUrl
            };
        }

        static DirectorDTO Convert(Director dir)
        {
            return new DirectorDTO()
            {
                Id = dir.Id,
                Name = dir.Name,
                DateOfBirth = dir.DateOfBirth,
                Gender = dir.Gender,
                Nationality = dir.Nationality,
                Biography = dir.Biography,
                ImageUrl = dir.ImageUrl
            };
        }
    }
}

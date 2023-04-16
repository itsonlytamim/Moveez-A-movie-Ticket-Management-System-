using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ActorService
    {
        public static List<ActorDTO> Get()
        {

            var data = DataAccessFactory.ActorData().Get();
            return Convert(data);

        }
        static List<ActorDTO> Convert(List<Actor> actors)
        {
            var data = new List<ActorDTO>();
            foreach (var ac in actors)
            {
                data.Add(new ActorDTO()
                {
                    Id = ac.Id,
                    Name = ac.Name,
                    Nationality = ac.Nationality,
                    Biography = ac.Biography,
                    DateOfBirth = ac.DateOfBirth,
                    ImageUrl= ac.ImageUrl,
                    Gender = ac.Gender,

                });
            }
            return data;

        }
    }


}

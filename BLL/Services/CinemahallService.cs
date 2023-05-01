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
    public class CinemahallService
    {
        public static List<CinemahallDTO> Get()
        {

            var data = DataAccessFactory.CinemahallData().Get();
            return Convert(data);

        }
        static List<CinemahallDTO> Convert(List<Cinemahall> cinemahalls)
        {
            var data = new List<CinemahallDTO>();
            foreach (var ch in cinemahalls)
            {
                data.Add(new CinemahallDTO()
                {
                    Id = ch.Id,
                    Name = ch.Name,
                    Address = ch.Address,
                    Capacity = ch.Capacity,
                });
            }
            return data;

        }

        public static CinemahallDTO GetById(int id)
        {
            var ch = DataAccessFactory.CinemahallData().GetById(id);
            if (ch != null)
            {
                return new CinemahallDTO()
                {
                    Id = ch.Id,
                    Name = ch.Name,
                    Address = ch.Address,
                    Capacity = ch.Capacity,
                };
            }
            return null;
        }

        public static void Add(CinemahallDTO cinemahall)
        {
            var ch = new Cinemahall()
            {
                Name = cinemahall.Name,
                Address = cinemahall.Address,
                Capacity = cinemahall.Capacity,
            };
            DataAccessFactory.CinemahallData().Add(ch);
        }

        public static void Update(CinemahallDTO cinemahall)
        {
            var ch = DataAccessFactory.CinemahallData().GetById(cinemahall.Id);
            if (ch != null)
            {
                ch.Name = cinemahall.Name;
                ch.Address = cinemahall.Address;
                ch.Capacity = cinemahall.Capacity;
                DataAccessFactory.CinemahallData().Update(ch);
            }
        }

        public static void Delete(int id)
        {
            var ch = DataAccessFactory.CinemahallData().GetById(id);
            if (ch != null)
            {
                DataAccessFactory.CinemahallData().Delete(ch);
            }
        }
    }
}

using BLL.DTOs;
using DAL.Models;
using DAL;
using System.Collections.Generic;
using System.Linq;

public class CinemahallService
{
    public static List<CinemahallDTO> Get()
    {
        var data = DataAccessFactory.CinemahallData().Get();
        return data.Select(Convert).ToList();
    }



    public static CinemahallDTO Get(int id)
    {
        return Convert(DataAccessFactory.CinemahallData().Get(id));
    }



    public static bool Create(CinemahallDTO cinemahall)
    {
        var data = Convert(cinemahall);
        var res = DataAccessFactory.CinemahallData().Insert(data);



        return res = true;
    }



    public static bool Delete(int id)
    {
        return DataAccessFactory.CinemahallData().Delete(id);
    }



    public static bool Update(CinemahallDTO cinemahall)
    {
        var data = Convert(cinemahall);
        var res = DataAccessFactory.CinemahallData().Update(data);



        return res = true;
    }



    public static bool Update(int id, CinemahallDTO cinemahall)
    {
        var existingCinemahall = DataAccessFactory.CinemahallData().Get(id);
        if (existingCinemahall == null) return false;



        existingCinemahall.Name = cinemahall.Name;
        existingCinemahall.Description = cinemahall.Description;
        existingCinemahall.SeatNo = cinemahall.SeatNo;
        existingCinemahall.Capacity = cinemahall.Capacity;
        existingCinemahall.Location = cinemahall.Location;



        var res = DataAccessFactory.CinemahallData().Update(existingCinemahall);



        return res = true;
    }



    private static CinemahallDTO Convert(Cinemahall cinemahall)
    {
        return new CinemahallDTO
        {
            Id = cinemahall.Id,
            Name = cinemahall.Name,
            Description = cinemahall.Description,
            SeatNo = cinemahall.SeatNo,
            Capacity = cinemahall.Capacity,
            Location = cinemahall.Location,
        };
    }



    private static Cinemahall Convert(CinemahallDTO cinemahall)
    {
        return new Cinemahall
        {
            Id = cinemahall.Id,
            Name = cinemahall.Name,
            Description = cinemahall.Description,
            SeatNo = cinemahall.SeatNo,
            Capacity = cinemahall.Capacity,
            Location = cinemahall.Location,
        };
    }
}
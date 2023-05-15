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
    public class MovieService
    {
        public static List<MovieDTO> Get()
        {
            var data = DataAccessFactory.MovieData().Get();
            return Convert(data);
        }

        public static MovieDTO Get(int id)
        {
            return Convert(DataAccessFactory.MovieData().Get(id));
        }

        public static bool Create(MovieDTO movie)
        {
            var data = Convert(movie);
            var res = DataAccessFactory.MovieData().Insert(data);

            if (res = true) return true;
            return false;
        }

       

        public static bool Delete(int id)
        {
            return DataAccessFactory.MovieData().Delete(id);
        }

        static List<MovieDTO> Convert(List<Movie> movies)
        {
            var data = new List<MovieDTO>();
            foreach (var movie in movies)
            {
                data.Add(Convert(movie));
            }
            return data;
        }

        static Movie Convert(MovieDTO movie)
        {
            return new Movie()
            {
                MovieId = movie.MovieId,
                Title = movie.Title,
                Description = movie.Description,
                ImageUrl = movie.ImageUrl,
                Year = movie.Year,
                Runtime = movie.Runtime,
                Language = movie.Language,
                ReleaseDate = movie.ReleaseDate,
                DirectorId = movie.DirectorId,
                CinemahallId = movie.CinemahallId
            };
        }

        static MovieDTO Convert(Movie movie)
        {
            return new MovieDTO()
            {
                MovieId = movie.MovieId,
                Title = movie.Title,
                Description = movie.Description,
                ImageUrl = movie.ImageUrl,
                Year = movie.Year,
                Runtime = movie.Runtime,
                Language = movie.Language,
                ReleaseDate = movie.ReleaseDate,
                DirectorId = movie.DirectorId,
                CinemahallId = movie.CinemahallId
            };


        }

        public static bool Update(MovieDTO movie)
        {
            var data = Convert(movie);
            var res = DataAccessFactory.MovieData().Update(data);

            if (res = true) return true;
            return false;
        }



        public static bool Update(int id, MovieDTO movie)
        {
            var existingMovie = DataAccessFactory.MovieData().Get(id);
            if (existingMovie == null) return false;

            existingMovie.Title = movie.Title;
            existingMovie.Description = movie.Description;
            existingMovie.ImageUrl = movie.ImageUrl;
            existingMovie.Year = movie.Year;
            existingMovie.Runtime = movie.Runtime;
            existingMovie.Language = movie.Language;
            existingMovie.ReleaseDate = movie.ReleaseDate;
            existingMovie.DirectorId = movie.DirectorId;
            existingMovie.CinemahallId = movie.CinemahallId;

            var res = DataAccessFactory.MovieData().Update(existingMovie);

            if (res = true) return true;
            return false;
        }

    }



}

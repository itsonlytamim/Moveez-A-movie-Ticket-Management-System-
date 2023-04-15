using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class MovieRepo : Repo, IRepo<Movie,int,bool>
    {
        public MovieRepo() : base() { }

        public List<Movie> Get()
        {
            return db.Movies.ToList();
        }

        public Movie Get(int id)
        {
            return db.Movies.Find(id);
        }

        public bool Insert(Movie movie)
        {
               db.Movies.Add(movie);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(Movie obj)
        {
            
            var existingMovie = db.Movies.Find(obj.MovieId);
            if (existingMovie != null) {
                existingMovie.Title = obj.Title;
                existingMovie.Description = obj.Description;
                existingMovie.ImageUrl = obj.ImageUrl;
                existingMovie.Year = obj.Year;
                existingMovie.Runtime = obj.Runtime;
                existingMovie.Language = obj.Language;
                existingMovie.ReleaseDate = obj.ReleaseDate;
                existingMovie.DirectorId = obj.DirectorId;
                existingMovie.CinemahallId = obj.CinemahallId;
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
            
                var movie = db.Movies.Find(id);
            if (movie != null) {
                db.Movies.Remove(movie);
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
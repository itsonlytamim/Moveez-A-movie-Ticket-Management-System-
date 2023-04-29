using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class MovieDTO
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Year { get; set; }
        public int Runtime { get; set; }
        public string Language { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int DirectorId { get; set; }
        public int CinemahallId { get; set; }
    }



}

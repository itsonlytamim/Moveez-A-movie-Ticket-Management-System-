using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Movie
    {
        
        public int MovieId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Year { get; set; }
        public int Runtime { get; set; }
        public string Language { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }
        public int DirectorId { get; set; }
        public int CinemahallId { get; set; }
        [ForeignKey("DirectorId")]
        public Director Director { get; set; }      
        [ForeignKey("CinemahallId")]
        public  Cinemahall Cinemahall { get; set; }
    }
}

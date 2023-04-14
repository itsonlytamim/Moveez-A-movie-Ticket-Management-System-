using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class MovieActor
    {
        [Key]
        public int Id { get; set; }
        public int MovieId { get; set; }

        [ForeignKey("MovieId")]
        public virtual Movie Movie { get; set; }

        public int ActorId { get; set; }

        [ForeignKey("ActorId")]
        public virtual Actor Actor { get; set; }
    }
}

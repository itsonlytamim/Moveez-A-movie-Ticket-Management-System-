using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Token
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string TokenString { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public Token()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}
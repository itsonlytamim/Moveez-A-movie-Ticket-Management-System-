using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs


{
    public class CinemahallDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfSeats { get; set; }
        public List<int> MovieIds { get; set; }
        public List<DateTime> Showtimes { get; set; }
    }
}

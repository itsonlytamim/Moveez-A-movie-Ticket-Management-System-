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
        public string SeatNo { get; set; }

        public int Capacity { get; set; }

        public string Location { get; set; }

    }
}
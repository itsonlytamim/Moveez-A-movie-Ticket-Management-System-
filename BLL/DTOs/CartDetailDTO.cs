﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CartDetailDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int MovieId { get; set; }
        public int CartId { get; set; }
    }

}

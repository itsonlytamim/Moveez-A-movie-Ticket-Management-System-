﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class NotificationDTO
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
    }
}
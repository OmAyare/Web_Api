﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Api.Models
{
    public class Employee
    {
        public int PostId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
    }
}

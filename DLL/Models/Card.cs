﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Models
{
    public class Card
    {
        public int Id { get; set; }
        public bool StatusPaid {  get; set; }
        public string UserId { get; set; }

        public int ProductId { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}

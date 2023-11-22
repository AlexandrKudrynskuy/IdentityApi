﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Models
{
    public class Brand
    {
        public int Id{ get; set; }
        public string Name { get; set; }   
        public string Photo { get; set; }
        public List<Product> Products { get; set; }=new List<Product>();
    }
}

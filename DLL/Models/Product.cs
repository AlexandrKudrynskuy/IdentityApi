using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal? OldPrice { get; set; }
        public int Count {  get; set; }
        public string Photo {  get; set; }   

        public int BrandId {  get; set; }
        public Brand Brand { get;set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<Card> Cards { get; set; } = new List<Card>();
    }
}

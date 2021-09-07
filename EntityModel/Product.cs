using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class Product
    {
        public Product()
        {
           // Brand = new Brand();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public decimal Price { get; set; }
        public short NumberStock { get; set; }
        public decimal DiscountRate { get; set; }
        public Brand Brand { get; set; }


    }
}

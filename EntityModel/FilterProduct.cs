using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class FilterProduct
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string Name { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public string Brand { get; set; }

    }
}

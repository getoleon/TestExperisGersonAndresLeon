using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public short ItemsQuantityCart { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Finished { get; set; }
        public User User { get; set; }

        public Product Product { get; set; }

    }
}

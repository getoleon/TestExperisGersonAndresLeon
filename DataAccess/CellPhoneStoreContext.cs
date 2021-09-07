using EntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CellPhoneStoreContext : DbContext
    {
        public CellPhoneStoreContext() : base("CellPhoneStoreDB")
        {
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<User> User { get; set; }


    }
}

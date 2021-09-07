using EntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDA
    {
        public List<Product> Get()
        {
            CellPhoneStoreContext db = new CellPhoneStoreContext();
            List<Product> lst = db.Product.ToList();
            return lst;
        }

        public Product Get(int idProduct)
        {
            CellPhoneStoreContext db = new CellPhoneStoreContext();
            Product Product = db.Product.Where(x => x.Id == idProduct).FirstOrDefault();
            return Product;
        }



        public List<Product> Get(FilterProduct piFilterProduct)
        {
            CellPhoneStoreContext db = new CellPhoneStoreContext();
            List<Product> lst = new List<Product>();

            using (var context = new CellPhoneStoreContext())
            {

                lst = context.Product.Include("Brand").ToList();

                if (!string.IsNullOrEmpty(piFilterProduct.Name))
                {
                    lst = lst.Where(x => x.Name.Contains(piFilterProduct.Name)).ToList();
                }

                if (piFilterProduct.MinPrice > 0 && piFilterProduct.MaxPrice > 0)
                {
                    lst = lst.Where(x => x.Price >= piFilterProduct.MinPrice && x.Price <= piFilterProduct.MaxPrice).ToList();
                }
                if (!string.IsNullOrEmpty(piFilterProduct.Brand))
                {
                    lst = lst.Where(x => x.Brand.Name == piFilterProduct.Brand).ToList();
                }

                if ((piFilterProduct.PageSize > 0 || piFilterProduct.Page > 0) && lst.Count > piFilterProduct.PageSize)
                {
                    lst = lst.Skip((piFilterProduct.Page - 1) * piFilterProduct.PageSize).Take(piFilterProduct.PageSize).ToList();
                }

            }

            return lst;
        }

   

        public void Add(List<Product> piLstProduct)
        {
            List<Product> vlLstProduct = new List<Product>();

            using (var context = new CellPhoneStoreContext())
            {
                foreach (var item in piLstProduct)
                {
                    if (!context.Product.Any(e => e.Name == item.Name))
                    {
                        item.Brand = context.Brand.Where(x => x.Name == item.Brand.Name).FirstOrDefault();
                        if (item.Brand != null)
                        {
                            vlLstProduct.Add(item);
                        }
                    }
                }
                context.Product.AddRange(vlLstProduct);
                context.SaveChanges();
            }
        }
    }

}


using EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BrandDA
    {
        public void Add(List<Brand> piLstBrand)
        {
            using (var context = new CellPhoneStoreContext())
            {
                context.Brand.AddRange(piLstBrand);
                context.SaveChanges();
            }
        }


        public void Add(Brand piBrand)
        {
            using (var context = new CellPhoneStoreContext())
            {
                context.Brand.Add(piBrand);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Valida la existencia de la marcar del celular
        /// </summary>
        /// <param name="piLstBrand"></param>
        public void AddUniqueName(List<Brand> piLstBrand)
        {
            piLstBrand = piLstBrand.GroupBy(x => x.Name).Select(x => x.FirstOrDefault()).ToList();
            using (var context = new CellPhoneStoreContext())
            {
                foreach (var itemBrand in piLstBrand)
                {
                    if (context.Brand.Where(e => e.Name == itemBrand.Name).FirstOrDefault() == null)
                    {
                        context.Brand.Add(itemBrand);
                    }
                }
                context.SaveChanges();
            }
        }

    }
}

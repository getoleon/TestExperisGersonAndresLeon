using DataAccess;
using EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BrandBLL
    {
        public void Add(Brand piBrand)
        {
            BrandDA vlBrandDA = new BrandDA();
            vlBrandDA.Add(piBrand);
        }

        /// <summary>
        /// Valida la existencia de la marcar del celular
        /// </summary>
        /// <param name="piLstBrand"></param>
        public void AddUniqueName(List<Brand> piLstBrand)
        {
            BrandDA vlBrandDA = new BrandDA();
            List<Brand> lstBrandProcess = new List<Brand>();
            vlBrandDA.AddUniqueName(piLstBrand);
        }


    }
}

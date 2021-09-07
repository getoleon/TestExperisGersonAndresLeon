using DataAccess;
using EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProductBLL
    {
        public List<Product> Get()
        {
            ProductDA vlProductDA = new ProductDA();

            return vlProductDA.Get();

        }

        public List<Product> Get(FilterProduct piFilterProduct)
        {
            ProductDA vlProductDA = new ProductDA();

            return vlProductDA.Get(piFilterProduct);

        }




        public bool ValidateStock(int IdProduct, int OrderQuantity)
        {
            ProductDA vlProductDA = new ProductDA();

            ShoppingCartBLL vlShoppingCartBLL = new ShoppingCartBLL();

            int availableProduct = vlProductDA.Get(IdProduct).NumberStock;

            int ShoppingCart = vlShoppingCartBLL.GetByIdProduct(IdProduct);

            if (availableProduct - ShoppingCart - OrderQuantity > 0)
            {
                return true;
            }

            return false;
        }
    }
}

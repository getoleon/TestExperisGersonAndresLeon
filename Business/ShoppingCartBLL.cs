using DataAccess;
using EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ShoppingCartBLL
    {
        public void Add(ShoppingCart piShoppingCar)
        {
            ShoppingCartDA VLShoppingCartDA = new ShoppingCartDA();
            piShoppingCar.CreationDate = DateTime.Now;
            piShoppingCar.Finished = false;
            VLShoppingCartDA.Add(piShoppingCar);
        }

        public int GetByIdProduct(int idProduct)
        {
            ShoppingCartDA VLShoppingCartDA = new ShoppingCartDA();
            return VLShoppingCartDA.GetByIdProduct(idProduct);
        }


        public List<ShoppingCart> GetCart(Guid UserId = default(Guid))
        {
            ShoppingCartDA VLShoppingCartDA = new ShoppingCartDA();
            return VLShoppingCartDA.GetCart(UserId);
        }

        public bool ClearCart(Guid UserId)
        {
            ShoppingCartDA VLShoppingCartDA = new ShoppingCartDA();
            return VLShoppingCartDA.ClearCart(UserId);
        }

        public bool FinishBuy(Guid UserId )
        {
            ShoppingCartDA VLShoppingCartDA = new ShoppingCartDA();
            return VLShoppingCartDA.FinishBuy(UserId);
        }
    }
}

using EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAccess
{
    public class ShoppingCartDA
    {
        public void Add(ShoppingCart piShoppingCar)
        {
            using (var context = new CellPhoneStoreContext())
            {
                piShoppingCar.Product = context.Product.Where(x => x.Id == piShoppingCar.Product.Id).FirstOrDefault();
                piShoppingCar.User = context.User.Where(x => x.Id == piShoppingCar.User.Id).FirstOrDefault();



                context.ShoppingCart.Add(piShoppingCar);
                context.SaveChanges();
            }
        }

        public int GetByIdProduct(int idProduct)
        {
            int vlActualStock = 0;

            using (var context = new CellPhoneStoreContext())
            {
                List<ShoppingCart> vlLstShoppingCart = context.ShoppingCart.Where(x => x.Product.Id == idProduct && x.Finished).ToList();


                if (vlLstShoppingCart.Count > 0)
                {
                    vlActualStock = vlLstShoppingCart.Sum(y => y.ItemsQuantityCart);
                }
            }


            return vlActualStock;
        }

        public bool FinishBuy(Guid userId)
        {
            using (var context = new CellPhoneStoreContext())
            {

                List<ShoppingCart> vlLstShoppingCart = context.ShoppingCart.Where(x => x.User.Id == userId && !x.Finished).Include(x => x.Product).ToList();

                foreach (var itemShopCart in vlLstShoppingCart)
                {
                    itemShopCart.Finished = true;
                    itemShopCart.Product.NumberStock = (short)(itemShopCart.Product.NumberStock - itemShopCart.ItemsQuantityCart);
                    context.Entry(itemShopCart).State = EntityState.Modified;
                }
                return context.SaveChanges() > 0 ? true : false;
            }
        }

        public bool ClearCart(Guid userId)
        {

            using (var context = new CellPhoneStoreContext())
            {

                List<ShoppingCart> vlLstShoppingCart = context.ShoppingCart.Where(x => x.User.Id == userId && x.Finished).ToList();

                foreach (var itemShopCart in vlLstShoppingCart)
                {
                    context.Entry(itemShopCart).State = EntityState.Deleted;
                }
                return context.SaveChanges() > 0 ? true : false;
            }
        }

        public List<ShoppingCart> GetCart(Guid UserId)
        {
            CellPhoneStoreContext db = new CellPhoneStoreContext();

            List<ShoppingCart> lst;

            if (UserId != Guid.Empty)
                lst = db.ShoppingCart.Where(x => !x.Finished).Include(x => x.Product.Brand).ToList();
            else
                lst = db.ShoppingCart.Where(x => !x.Finished && x.User.Id == UserId).Include(x => x.Product.Brand).ToList();

            return lst;
        }
    }
}

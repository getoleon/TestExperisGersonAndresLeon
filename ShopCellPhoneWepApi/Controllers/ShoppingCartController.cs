using Business;
using EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopCellPhoneWepApi.Controllers
{
    public class ShoppingCartController : ApiController
    {

        [HttpPost]
        [Route("api/ShoppingCart/AddProduct")]
        public HttpResponseMessage AddProduct(ShoppingCart piShoppingCart)
        {
            HttpResponseMessage httpMsg = null;
            ShoppingCartBLL vlShoppingCartBLL = new ShoppingCartBLL();
            ProductBLL vlProductBLL = new ProductBLL();

            try
            {
                if (vlProductBLL.ValidateStock(piShoppingCart.Product.Id, piShoppingCart.ItemsQuantityCart))
                {
                    vlShoppingCartBLL.Add(piShoppingCart);
                    httpMsg = Request.CreateResponse(HttpStatusCode.OK, "Producto agregado al carrito correctamente.");
                }
                else
                {
                    httpMsg = Request.CreateErrorResponse(HttpStatusCode.PreconditionFailed, "Sin stock disponible");
                }
            }
            catch (Exception ex)
            {
                httpMsg = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return httpMsg;
        }

        [HttpPost]
        [Route("api/shoppingcart/clearcart")]
        public HttpResponseMessage ClearCart([FromBody] string IdUser)
        {
            HttpResponseMessage httpMsg = null;
            ShoppingCartBLL vlShoppingCartBLL = new ShoppingCartBLL();

            try
            {
                httpMsg = Request.CreateResponse(HttpStatusCode.OK, vlShoppingCartBLL.ClearCart(Guid.Parse(IdUser)));
            }
            catch (Exception ex)
            {
                httpMsg = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return httpMsg;
        }

        [HttpPost]
        [Route("api/shoppingcart/finishbuy")]
        public HttpResponseMessage FinishBuy([FromBody] string IdUser)
        {
            HttpResponseMessage httpMsg = null;
            ShoppingCartBLL vlShoppingCartBLL = new ShoppingCartBLL();

            try
            {
                httpMsg = Request.CreateResponse(HttpStatusCode.OK, vlShoppingCartBLL.FinishBuy(Guid.Parse(IdUser)));
            }
            catch (Exception ex)
            {
                httpMsg = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return httpMsg;
        }
    }
}

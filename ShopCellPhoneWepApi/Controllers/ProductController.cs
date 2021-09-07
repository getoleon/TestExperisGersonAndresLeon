using Business;
using EntityModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;

namespace ShopCellPhoneWepApi.Controllers
{
    public class ProductController : ApiController
    {
        public HttpResponseMessage Get(FilterProduct piFilterProduct)
        {

            ProductBLL vlProductBLL = new ProductBLL();
            HttpResponseMessage httpMsg = null;

            try
            {
                List<Product> vlLstreturn = vlProductBLL.Get(piFilterProduct);
                httpMsg = Request.CreateResponse(HttpStatusCode.OK, vlLstreturn);
            }
            catch (Exception ex)
            {
                httpMsg = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return httpMsg;

        }

        [HttpPost]
        [Route("api/Product/UploadFile")]
        public HttpResponseMessage UploadFile()
        {
            string vlFormatFile = WebConfigurationManager.AppSettings["FormatFileCSV"];
            bool vlValidateFormatColumn = Boolean.Parse(WebConfigurationManager.AppSettings["ValidateFormatColumn"]);
            System.IO.Stream MyStream;
            HttpResponseMessage httpMsg = null;

            try
            {
                var file = HttpContext.Current.Request.Files.Count > 0 ?
               HttpContext.Current.Request.Files[0] : null;


                if (file != null && file.ContentLength > 0)
                {
                    var fileName = System.IO.Path.GetFileName(file.FileName);
                    MyStream = file.InputStream;
                    ProcessFileCsvBLL vlProcessFileCsvBLL = new ProcessFileCsvBLL(vlFormatFile);
                    vlProcessFileCsvBLL.ReaderFile(MyStream, vlValidateFormatColumn);
                    httpMsg = Request.CreateErrorResponse(HttpStatusCode.OK, "Archivo procesado");
                }
            }
            catch (Exception ex)
            {
                httpMsg = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return httpMsg;
        }


        [HttpPost]
        [Route("api/Product/ProductCarById")]
        public HttpResponseMessage ProductCarById([FromBody] string IdUser)
        {
            ShoppingCartBLL vlShoppingCartBLL = new ShoppingCartBLL();
            HttpResponseMessage httpMsg = null;

            try
            {
                httpMsg = Request.CreateResponse(HttpStatusCode.OK, vlShoppingCartBLL.GetCart(Guid.Parse(IdUser)).Select(x => new { x.Product.Name, x.Product.Brand, x.ItemsQuantityCart }));
            }
            catch (Exception ex)
            {
                httpMsg = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return httpMsg;

        }



    }
}

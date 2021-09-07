using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ShopCellPhoneWepApi.Controllers;
using EntityModel;
using System.Web.Http.Results;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace ShopCellPhoneWepApi.Tests.Controllers
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void Get()
        {

            ProductController controller = new ProductController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            FilterProduct piFilterProduct = new FilterProduct();
            piFilterProduct.Page = 1;
            piFilterProduct.PageSize = 5;
            piFilterProduct.Name = "6";
            piFilterProduct.MinPrice = 0;
            piFilterProduct.MaxPrice = 0;
            piFilterProduct.Brand = "Huawey";

            var response = controller.Get(piFilterProduct); 
            Assert.IsNotNull(response);

        }
        [TestMethod]
        public void ProductCarById()
        {

            ProductController controller = new ProductController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            //string idUser = "";
            
            //var response = controller.ProductCarById();
            //Assert.IsNotNull(response);

        }

        
    }
}

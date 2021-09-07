using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopCellPhoneWepApi;
using ShopCellPhoneWepApi.Controllers;
using System.Web.Mvc;

namespace ShopCellPhoneWepApi.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Disponer
            HomeController controller = new HomeController();

            // Actuar
            ViewResult result = controller.Index() as ViewResult;

            // Declarar
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserMock.Example.Mvc3;
using UserMock.Example.Mvc3.Controllers;

namespace UserMock.Example.Mvc3.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Welcome to ASP.NET MVC!", result.ViewBag.Message);
        }

        [TestMethod]
        public void SecureArea()
        {
            // Arrange
            HomeController controller = new HomeController();
            var user = UserMock.CreateUser("Kevin");

            // Act
            user.DoAction((u) =>
            {
                ViewResult result = controller.SecureArea() as ViewResult;

                // Assert
                Assert.AreEqual("Kevin", result.ViewBag.UserName);
            });

        }
    }
}

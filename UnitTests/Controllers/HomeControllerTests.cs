using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebApp.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod()]
        public void SendRequest_Downtown()
        {
            var controller = new HomeController();
            var obj = new Models.ServiceInput() { latitude = "+48.4251378" , longitude = "-123.3646335" };
            var result = controller.Index(obj) as ViewResult;

            Models.ServiceInput res = (Models.ServiceInput)result.Model;
            Assert.AreEqual("Downtown Victoria/Vic West", res.result);
        }

        [TestMethod()]
        public void SendRequest_Cowichan()
        {
            var controller = new HomeController();
            var obj = new Models.ServiceInput() { latitude = "+48.8277", longitude = "-123.711" };
            var result = controller.Index(obj) as ViewResult;

            Models.ServiceInput res = (Models.ServiceInput)result.Model;
            Assert.AreEqual("Central Cowichan", res.result);
        }

        [TestMethod()]
        public void SendRequest_Sooke()
        {
            var controller = new HomeController();
            var obj = new Models.ServiceInput() { latitude = "+48.4251378", longitude = "-123.711" };
            var result = controller.Index(obj) as ViewResult;

            Models.ServiceInput res = (Models.ServiceInput)result.Model;
            Assert.AreEqual("Sooke", res.result);
        }

        [TestMethod()]
        public void SendRequest_Pender()
        {
            var controller = new HomeController();
            var obj = new Models.ServiceInput() { latitude = "+48.8277", longitude = "-123.3646335" };
            var result = controller.Index(obj) as ViewResult;

            Models.ServiceInput res = (Models.ServiceInput)result.Model;
            Assert.AreEqual("Pender/Galiano/Saturna/Mayne", res.result);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity3.Controllers
{
    public class TestController : Controller
    {
        [HttpGet]
        [CustomAuthorization]
        public ActionResult Index()
        {
            return Content("I am in the test controller. I should be protected content because of the CustomAuthorization Attribute.");
        }


        [HttpGet]
        public ActionResult LessSecureMethod()
        {
            return Content("I am less protected content.");
        }
    }
}
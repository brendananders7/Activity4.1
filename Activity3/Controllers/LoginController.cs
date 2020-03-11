using Activity3.Models;
using Activity3.Services.Business;
using Activity3.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
//using System.Runtime.Caching;

namespace Activity3.Controllers
{
    public class LoginController : Controller
    {
        private static MyLogger1 logger = MyLogger1.GetInstance();
        [HttpGet]
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(UserModel user)
        {
            MyLogger1.GetInstance().Info("Entering LoginController.DoLogin()");
            MyLogger1.GetInstance().Info("Parameters are: {0}", new JavaScriptSerializer().Serialize(user));
            try
            {
                //Validate the Form POST
                if (!ModelState.IsValid)
                    return View("Login");

                //Call the Security Business Service Authenticate() method from the Login() method
                //and save the results of the method call in a local method variable

                SecurityService securityService = new SecurityService();
                Boolean success = securityService.Authenticate(user);

                if (success)
                {
                    MyLogger1.GetInstance().Info("Exit LoginController.Login() with login passing");
                    return View("LoginSuccess", user);
                }

                else
                {
                    MyLogger1.GetInstance().Info("Exit LoginController.Login() with login failing");
                    return View("LoginFailed");
                }
            }
            catch (Exception e)
            {
                MyLogger1.GetInstance().Error("Exception LoginController.Login() " + e.Message);
                return View("Login");
            }

        }
    }
}
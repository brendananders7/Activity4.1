using Activity3.Models;
using Activity3.Services.Business;
using Activity3.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
//using System.Runtime.Caching;

namespace Activity3.Controllers
{
    [CustomAction]
    public class LoginController : Controller
    {
        private static MyLogger1 logger = MyLogger1.GetInstance();

        [HttpGet]
        public string GetUsers()
        {
            var cache = MemoryCache.Default;

            List<UserModel> users = cache.Get("Users") as List<UserModel>;
            if(users == null)
            {
                MyLogger1.GetInstance().Info("Brendan's App: Creating Users and putting them into a cache");

                users = new List<UserModel>();
                users.Add(new UserModel("Mark", "Test1"));
                users.Add(new UserModel("Justine", "Test1"));
                users.Add(new UserModel("Brianna", "Test1"));

                var policy = new CacheItemPolicy().AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60.0);
                cache.Set("Users", users, policy);
            }

            else
            {
                MyLogger1.GetInstance().Info("Brendan's App: Got users from cache");
            }
            return new JavaScriptSerializer().Serialize(users);
        }

        [HttpGet]
        [CustomAuthorization]
        public ActionResult PrivateSectionMustBeLoggedIn()
        {
            return Content("I am a protected method if the proper attribute is applied to me");
        }

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
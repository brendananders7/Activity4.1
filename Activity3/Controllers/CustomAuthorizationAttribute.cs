using System;
using System.Web.Mvc;

namespace Activity3.Controllers
{
    internal class CustomAuthorizationAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            //TODO: This is where the security token and security business logic would need to be run
            filterContext.Result = new RedirectResult("/Login");
        }
    }
}
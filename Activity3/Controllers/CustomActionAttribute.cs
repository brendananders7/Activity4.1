using Activity3.Services.Utility;
using System;
using System.Web.Mvc;

namespace Activity3.Controllers
{
    internal class CustomActionAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string name = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + ":" +
                filterContext.ActionDescriptor.ActionName;
            MyLogger1.GetInstance().Info("Existing Controller: " + name);
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string name = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + ":" +
                filterContext.ActionDescriptor.ActionName;
            MyLogger1.GetInstance().Info("Entering Controller: " + name);
        }
    }
}
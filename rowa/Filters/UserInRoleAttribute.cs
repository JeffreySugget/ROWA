using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;

namespace rowa.Filters
{
    public class UserInRoleAttribute : ActionFilterAttribute
    {
        private readonly string _roleName;

        public UserInRoleAttribute(string roleName)
        {
            _roleName = roleName;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User.IsInRole(_roleName)) return;

            MethodInfo methodInfo = filterContext.Controller.GetType()
                .GetMethod("RedirectToAction",
                           BindingFlags.ExactBinding |
                           BindingFlags.NonPublic |
                           BindingFlags.Instance, null,
                           new[]
                               {
                                typeof (RouteValueDictionary)
                               }, null);
            methodInfo.Invoke(filterContext.Controller,
                              new object[]
                                  {
                                        new RouteValueDictionary(
                                          new
                                              {
                                                  controller = "Account",
                                                  action = "LogIn",
                                                  redirect = filterContext.HttpContext.Request.Url.AbsolutePath
                                              })
                                  });

            base.OnActionExecuting(filterContext);
        }
    }
}
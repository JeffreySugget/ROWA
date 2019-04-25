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

            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "LogIn", controller = "Account" }));

            base.OnActionExecuting(filterContext);
        }
    }
}
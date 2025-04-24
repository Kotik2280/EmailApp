using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace EmailApp.Attributes
{
    public class CheckAuthorizationAttribute : ActionFilterAttribute
    {
        string _redirectRoute;

        public CheckAuthorizationAttribute(string redirectRoute = "Profile")
        {
            _redirectRoute = redirectRoute;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity?.IsAuthenticated == true)
            {
                context.Result = new RedirectToRouteResult(new {Controller="Authorized", Action="Profile"});
            }
            
            base.OnActionExecuting(context);
        }
    }
}

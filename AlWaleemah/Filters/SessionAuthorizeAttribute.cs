using Microsoft.AspNetCore.Mvc.Filters;

namespace AlWaleemah.Filters
{
    public class SessionAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session;
            if (string.IsNullOrEmpty(session.GetString("Username")))
            {
                // If the user is not logged in, redirect to the login page
                context.HttpContext.Response.Redirect("/Account/Login");
            }
            base.OnActionExecuting(context);
        }
    }
}

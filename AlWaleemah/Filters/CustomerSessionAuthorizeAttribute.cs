using Microsoft.AspNetCore.Mvc.Filters;

namespace AlWaleemah.Filters
{
    public class CustomerSessionAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var username = context.HttpContext.Session.GetString("UsernameCustomer");
            if (string.IsNullOrEmpty(username))
            {
                context.HttpContext.Response.Redirect("/CustomerClient/login");
            }
            base.OnActionExecuting(context);
        }
    }
}

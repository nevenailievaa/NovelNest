namespace NovelNest.Attributes
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using NovelNest.Core.Contracts;
    using System.Security.Claims;

    public class MustBePublisherAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            IPublisherService? publisherService = context.HttpContext.RequestServices.GetService<IPublisherService>();

            if (publisherService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (publisherService != null && publisherService.ExistsByUserIdAsync(context.HttpContext.User.Id()).Result == false)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
            }
        }
    }
}
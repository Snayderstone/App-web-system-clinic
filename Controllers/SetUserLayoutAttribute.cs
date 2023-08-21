using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AppWebSistemaClinica.Controllers
{
    public class SetUserLayoutAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!(context.Controller is Controller controller)) return;

            controller.ViewBag.Layout = "~/Views/Shared/_LayoutUser.cshtml";
            base.OnActionExecuting(context);
        }
    }
}

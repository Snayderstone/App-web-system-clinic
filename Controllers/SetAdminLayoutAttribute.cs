using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AppWebSistemaClinica.Controllers
{
    public class SetAdminLayoutAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!(context.Controller is Controller controller)) return;

            controller.ViewBag.Layout = "~/Views/Shared/_LayoutAdmin.cshtml";
            base.OnActionExecuting(context);
        }
    }
}
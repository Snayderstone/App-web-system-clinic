using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AppWebSistemaClinica.Controllers
{
    public class SetProfLayoutAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!(context.Controller is Controller controller)) return;

            controller.ViewBag.Layout = "~/Views/Shared/_LayoutProf.cshtml";
            base.OnActionExecuting(context);
        }
    }
}

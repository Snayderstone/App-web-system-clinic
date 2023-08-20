using AppWebSistemaClinica.C3BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace AppWebSistemaClinica.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class AdministradorController : Controller
    {

       
        public IActionResult IndexAdmin()
        {
            return View();
        }
        [HttpGet]
        [Route("Tablas")]
        public IActionResult TablasAdmin()
        {
            ViewBag.Layout = "~/Views/Shared/_LayoutAdmin.cshtml";
            return View();
        }
        [HttpGet]
        [Route("Gráficos")]
        public IActionResult GraficosAdmin()
        {
            ViewBag.Layout = "~/Views/Shared/_LayoutAdmin.cshtml";
            return View();
        }
    }
}

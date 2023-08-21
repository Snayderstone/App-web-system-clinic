using AppWebSistemaClinica.C3BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace AppWebSistemaClinica.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    [SetAdminLayout] // Aplicar el atributo personalizado aquí
    public class AdministradorController : Controller
    {
        [HttpGet]
        [Route("Index Admin")]
        public IActionResult IndexAdmin()
        {
            return View();
        }

        [HttpGet]
        [Route("Tablas")]
        public IActionResult TablasAdmin()
        {
            return View();
        }

        [HttpGet]
        [Route("Gráficos")]
        public IActionResult GraficosAdmin()
        {
            return View();
        }
    }
}

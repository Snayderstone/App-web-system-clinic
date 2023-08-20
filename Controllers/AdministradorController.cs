using AppWebSistemaClinica.C3BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace AppWebSistemaClinica.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class AdministradorController : Controller
    {

        [HttpGet]
        [Route("Api/[controller]")]
        public IActionResult IndexAdmin()
        {
            return View();
        }

    }
}

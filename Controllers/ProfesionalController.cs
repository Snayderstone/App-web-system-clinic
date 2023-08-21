using Microsoft.AspNetCore.Mvc;

namespace AppWebSistemaClinica.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    [SetProfLayout] // Aplicar el atributo personalizado aquí
    public class ProfesionalController : Controller
    {
        [HttpGet]
        [Route("Index Prof")]
        public IActionResult IndexProf()
        {
            return View();
        }


    }
}

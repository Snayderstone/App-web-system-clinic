using Microsoft.AspNetCore.Mvc;

namespace AppWebSistemaClinica.Models
{
    public class RegistroMedicoViewModel : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace AppWebSistemaClinica.Models
{
    public class PerfilViewModel : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

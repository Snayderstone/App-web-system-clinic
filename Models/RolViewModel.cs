using Microsoft.AspNetCore.Mvc;

namespace AppWebSistemaClinica.Models
{
    public class RolViewModel : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

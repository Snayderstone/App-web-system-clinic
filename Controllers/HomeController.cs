using AppWebSistemaClinica.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AppWebSistemaClinica.Controllers
{

    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //INICIO DEL SITIO
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contactanos()
        {
            return View();
        }

        public IActionResult Departamentos()
        {
            return View();
        }
       
        public IActionResult Acceso()
        {
            return View();
        }

        public IActionResult Registro()
        {
            return View();
        }

        public IActionResult MasInformacion()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public IActionResult IndexAdmin()
        //{
        //    //return View("~/Views/Administrador/IndexAdmin.cshtml");
        //    // Establecer el diseño específico
        //    ViewData["Layout"] = "~/Views/Shared/_LayoutAdmin.cshtml";
        //    return View("~/Views/Administrador/IndexAdmin.cshtml");
        //}

        public IActionResult IndexAdmin()
        {
            ViewData["Title"] = "Administración";
            ViewBag.Layout = "~/Views/Shared/_LayoutAdmin.cshtml";
            return View("~/Views/Administrador/IndexAdmin.cshtml"); // Especificar la ruta completa de la vista
        }

    }
}
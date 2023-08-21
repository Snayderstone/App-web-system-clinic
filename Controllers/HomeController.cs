using AppWebSistemaClinica.C1Model;
using AppWebSistemaClinica.C3BusinessLogic;
using AppWebSistemaClinica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NuGet.Protocol;
using System.Diagnostics;

namespace AppWebSistemaClinica.Controllers
{

    public class HomeController : Controller
    {

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        private readonly C3BusinessLogicUsuario _usuarioLogic;

        public HomeController(C3BusinessLogicUsuario usuarioLogic)
        {
            _usuarioLogic = usuarioLogic;
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



        [HttpGet]
        [Route("Registro")]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [Route("Registro")]
        public IActionResult Registro([FromForm] UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //// Verificar si ya existe un usuario con el mismo correo electrónico
                    //var usuarioExistente = _usuarioLogic.buscarUsuarioPorCorreo(usuarioViewModel.CorreoElectronico);
                    //if (usuarioExistente != null)
                    //{
                    //    ModelState.AddModelError("", "Ya existe un usuario con este correo electrónico.");
                    //    return View(usuarioViewModel);
                    //}
                    //// Validación de contraseña
                    //if (usuarioViewModel.ContrasenaUsuario != usuarioViewModel.ConfirmacionContrasena)
                    //{
                    //    ModelState.AddModelError(string.Empty, "La contraseña y su confirmación no coinciden.");
                    //    return View(usuarioViewModel);
                    //}
                    var clienteModel = new C1ModelUsuario
                    {
                        NombreUsuario = usuarioViewModel.NombreUsuario,
                        ApellidoUsuario = usuarioViewModel.ApellidoUsuario,
                        CorreoElectronico = usuarioViewModel.CorreoElectronico,
                        ContrasenaUsuario = usuarioViewModel.ContrasenaUsuario,
                        FechaRegistro = DateTime.Now, // Asigna la fecha actual aquí
                    };

                    _usuarioLogic.insertarUsuario(clienteModel);

                    return RedirectToAction("RegistroExitoso");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Error al crear el cliente: " + ex.Message);
                }
            }
            // Devuelve la vista con el modelo inválido
            return View(usuarioViewModel);
        }

        [HttpGet]
        [Route("RegistroExitoso")]
        public IActionResult RegistroExitoso()
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



        public IActionResult IndexAdmin()
        {
            ViewData["Title"] = "Administración";
            ViewBag.Layout = "~/Views/Shared/_LayoutAdmin.cshtml";
            return View("~/Views/Administrador/IndexAdmin.cshtml"); // Especificar la ruta completa de la vista
        }

        public IActionResult IndexUser()
        {
            ViewData["Title"] = "Pacientes";
            ViewBag.Layout = "~/Views/Shared/_LayoutUser.cshtml";
            return View("~/Views/Usuario/IndexUser.cshtml"); // Especificar la ruta completa de la vista
        }

        public IActionResult IndexProf()
        {
            ViewData["Title"] = "Profesionales";
            ViewBag.Layout = "~/Views/Shared/_LayoutProf.cshtml";
            return View("~/Views/Profesional/IndexProf.cshtml"); // Especificar la ruta completa de la vista
        }
    }
}
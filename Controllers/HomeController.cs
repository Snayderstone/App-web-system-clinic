using AppWebSistemaClinica.C1Model;
using AppWebSistemaClinica.C3BusinessLogic;
using AppWebSistemaClinica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using NuGet.Protocol;
using System.Diagnostics;

namespace AppWebSistemaClinica.Controllers
{

    public class HomeController : Controller
    {

        private readonly C3BusinessLogicUsuario _usuarioLogic;
        private readonly C3BusinessLogicRol _rolLogic;
        private readonly C3BusinessLogicPerfil _perfilLogic;

        public HomeController(C3BusinessLogicUsuario usuarioLogic, C3BusinessLogicRol rolLogic, C3BusinessLogicPerfil perfilLogic)
        {
            _usuarioLogic = usuarioLogic;
            _rolLogic = rolLogic;
            _perfilLogic = perfilLogic;
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
       
        public IActionResult MasInformacion()
        {
            return View();
        }

        [HttpGet]
        [Route("Registro")]
        public IActionResult Registro()
        {
            var rolesDisponibles = _rolLogic.imprimirRoles(); // Obtén los roles disponibles desde tu lógica de negocio
            ViewBag.RolesDisponibles = new SelectList(rolesDisponibles, "IdRol", "NombreRol");
            return View();
        }

        [HttpPost]
        [Route("Registro")]
        public IActionResult Registro(UsuarioViewModel usuarioViewModel)
        {
          
            if (ModelState.IsValid)
            {
                try
                {
        
                    var usuarioModel = new C1ModelUsuario
                    {
                        NombreUsuario = usuarioViewModel.NombreUsuario,
                        ApellidoUsuario = usuarioViewModel.ApellidoUsuario,
                        CorreoElectronico = usuarioViewModel.CorreoElectronico,
                        ContrasenaUsuario = usuarioViewModel.ContrasenaUsuario,
                        FechaRegistro = DateTime.Now, // Asigna la fecha actual aquí

                    };
                    _usuarioLogic.insertarUsuario(usuarioModel);
                    // Crear perfil asociado
                    var perfilModel = new C1ModelPerfil
                    {
                        IdUsuario = usuarioModel.IdUsuario, // Obtén el IdUsuario creado anteriormente
                        IdRol = usuarioViewModel.IdRolSeleccionado // Obtén el IdRol seleccionado en el formulario
                    };
                    _perfilLogic.insertarPerfil(perfilModel);

                    return RedirectToAction("RegistroExitoso");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Error al crear el cliente: " + ex.Message);
                }
            }
            // Obtén nuevamente la lista de roles disponibles y agrégala a la ViewBag
            ViewBag.RolesDisponibles = new SelectList(_rolLogic.imprimirRoles(), "IdRol", "NombreRol");
            // Devuelve la vista con el modelo inválido
            return View(usuarioViewModel);
        }

        [HttpGet]
        [Route("RegistroExitoso")]
        public IActionResult RegistroExitoso()
        {
            return View();
        }





        // get para traer y validar los datos que escribio el user
        [HttpGet]
        [Route("Acceso")]
        public IActionResult Acceso()
        {
            return View();
        }
        // Pst para mandar los camp escrito por los user
        [HttpPost]
        [Route("Acceso")]
        public IActionResult Acceso1()
        {
            return View();
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
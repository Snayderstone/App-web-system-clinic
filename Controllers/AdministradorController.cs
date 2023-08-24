using AppWebSistemaClinica.C1Model;
using AppWebSistemaClinica.C3BusinessLogic;
using AppWebSistemaClinica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace AppWebSistemaClinica.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    [SetAdminLayout] // Aplicar el atributo personalizado aquí
    public class AdministradorController : Controller
    {

        private readonly C3BusinessLogicUsuario _usuarioLogic;
        private readonly C3BusinessLogicRol _rolLogic;
        private readonly C3BusinessLogicPerfil _perfilLogic;

        public AdministradorController(C3BusinessLogicUsuario usuarioLogic, C3BusinessLogicRol rolLogic, C3BusinessLogicPerfil perfilLogic)
        {
            _usuarioLogic = usuarioLogic;
            _rolLogic = rolLogic;
            _perfilLogic = perfilLogic;
        }


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

        [HttpGet]
        [Route("ImprimirRoles")]
        public IActionResult ImprimirRoles()
        {
            try
            {
                var roles = _rolLogic.imprimirRoles();
                var viewModelList = roles.Select(r => new RolViewModel
                {
                    IdRol = r.IdRol,
                    NombreRol = r.NombreRol,
                    DescripcionRol = r.DescripcionRol,
                }).ToList();

                return View(viewModelList);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener los roles: " + ex.Message });
            }

        }

        [HttpGet]
        [Route("CrearRol")]
        public IActionResult CrearRol()
        {
            return View();
        }

        [HttpPost]
        [Route("CrearRol")]
        public IActionResult CrearRol([FromForm] RolViewModel rolViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var rolModel = new C1ModelRol
                    {
                        NombreRol = rolViewModel.NombreRol,
                        DescripcionRol = rolViewModel.DescripcionRol,
                    };
                    _rolLogic.insertarRol(rolModel);
                    return RedirectToAction("ImprimirRoles");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Error al crear el rol: " + ex.Message);
                }
            }
            return View("~/Views/Administrador/CrearRol.cshtml", rolViewModel);
        }


        [HttpGet]
        [Route("Rol/Editar/{id}")]
        public IActionResult EditarRol(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Obtener el rol por su ID
                    C1ModelRol rolModel = _rolLogic.buscarRolPorId(id);

                    // Convertir el modelo a un ClienteViewModel
                    RolViewModel rolViewModel = new RolViewModel
                    {
                        IdRol = rolModel.IdRol,
                        NombreRol = rolModel.NombreRol,
                        DescripcionRol = rolModel.DescripcionRol,
                    };

                    return View("EditarRol", rolViewModel);
                }
                catch (Exception ex)
                {
                    // Manejar el error adecuadamente
                    ModelState.AddModelError(string.Empty, "Error al buscar el cliente por su id: " + ex.Message);
                }
            }
            return RedirectToAction("ImprimirRoles");
        }

        [HttpPost]
        [Route("EditarRol")]
        public IActionResult EditarRol(RolViewModel rolViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var rolModel = new C1ModelRol
                    {
                        IdRol = rolViewModel.IdRol,
                        NombreRol = rolViewModel.NombreRol,
                        DescripcionRol = rolViewModel.DescripcionRol,
                    };

                    _rolLogic.actualizarRol(rolModel);

                    return RedirectToAction("ImprimirRoles");
                }

                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Error al actualizar el rol: " + ex.Message);
                }
            }

            return View(rolViewModel);
        }


        [HttpGet]
        [Route("EliminarRol/{id}")]
        public IActionResult EliminarRol(int id)
        {
            try
            {
                _rolLogic.eliminarRol(id);

                return RedirectToAction("ImprimirRoles");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al eliminar el rol: " + ex.Message });
            }
        }
    }
}

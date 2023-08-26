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
        [Route("Graficos")]
        public IActionResult GraficosPerfil()
        {
            try
            {
                var cantidadUsuariosPorRol = _perfilLogic.ObtenerCantidadUsuariosPorRol();

                ViewBag.CantidadUsuariosPorRol = cantidadUsuariosPorRol;

                return View();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener la cantidad de usuarios por rol: " + ex.Message });
            }
        }

        [HttpGet]
        [Route("Perfiles")]
        public IActionResult ImprimirPerfiles()
        {
            try
            {
                var perfiles = _perfilLogic.obtenerUsuariosPerfilesRolesEager();
                var viewModelList = perfiles.Select(p => new PerfilViewModel
                {
                    IdPerfil = p.IdPerfil,
                    IdUsuario = p.C1ModelUsuario.IdUsuario,
                    NombreUsuario = p.C1ModelUsuario.NombreUsuario,
                    ApellidoUsuario = p.C1ModelUsuario.ApellidoUsuario,
                    CorreoElectronico = p.C1ModelUsuario.CorreoElectronico,
                    IdRol = p.C1ModelRol.IdRol,
                    NombreRol = p.C1ModelRol.NombreRol,
                    DescripcionRol = p.C1ModelRol.DescripcionRol,
                }).ToList();

                return View(viewModelList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener los perfiles: " + ex.Message });
            }
        }

        [HttpGet]
        [Route("CrearPerfil")]
        public IActionResult CrearPerfil()
        {
            var roles = _rolLogic.imprimirRoles();
            ViewBag.Roles = new SelectList(roles, "IdRol", "NombreRol");

            var correos = _usuarioLogic.imprimirUsuario();
            ViewBag.Correos = new SelectList(correos, "IdUsuario", "CorreoElectronico");

            return View();
        }

        [HttpPost]
        [Route("CrearPerfil")]
        public IActionResult CrearPerfil([FromForm] PerfilViewModel perfilViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var perfilModel = new C1ModelPerfil
                    {
                        IdUsuario = perfilViewModel.IdUsuario,
                        IdRol = perfilViewModel.IdRol
                    };
                    _perfilLogic.insertarPerfil(perfilModel);
                    return RedirectToAction("ImprimirPerfiles");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Error al crear el perfil: " + ex.Message);
                }
            }
            ViewBag.Correos = new SelectList(_usuarioLogic.imprimirUsuario(), "IdUsuario", "CorreoElectronico", perfilViewModel.IdUsuario);
            ViewBag.Roles = new SelectList(_rolLogic.imprimirRoles(), "IdRol", "NombreRol", perfilViewModel.IdRol);
            return View(perfilViewModel);
        }

 
        [HttpGet]
        [Route("Perfil/Editar/{id}")]
        public IActionResult EditarPerfil(int id)
        {
            try
            {
                var perfilModel = _perfilLogic.buscarPerfilPorId(id);

                var perfilViewModel = new PerfilViewModel
                {
                    IdPerfil = perfilModel.IdPerfil,
                    IdUsuario = perfilModel.IdUsuario,
                    IdRol = perfilModel.IdRol
                };

                ViewBag.Correos = new SelectList(_usuarioLogic.imprimirUsuario(), "IdUsuario", "CorreoElectronico", perfilViewModel.IdUsuario);
                ViewBag.Roles = new SelectList(_rolLogic.imprimirRoles(), "IdRol", "NombreRol", perfilViewModel.IdRol);

                return View(perfilViewModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error al buscar el perfil: " + ex.Message);
                return RedirectToAction("ImprimirPerfiles");
            }
        }

        [HttpPost]
        [Route("Perfil/Editar/{id}")]
        public IActionResult EditarPerfil(int id, [FromForm] PerfilViewModel perfilViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var perfilModel = new C1ModelPerfil
                    {
                        IdPerfil = perfilViewModel.IdPerfil,
                        IdUsuario = perfilViewModel.IdUsuario,
                        IdRol = perfilViewModel.IdRol
                    };

                    _perfilLogic.actualizarPerfil(perfilModel);

                    return RedirectToAction("ImprimirPerfiles");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Error al actualizar el perfil: " + ex.Message);
                }
            }

            ViewBag.Correos = new SelectList(_usuarioLogic.imprimirUsuario(), "IdUsuario", "CorreoElectronico", perfilViewModel.IdUsuario);
            ViewBag.Roles = new SelectList(_rolLogic.imprimirRoles(), "IdRol", "NombreRol", perfilViewModel.IdRol);

            return View(perfilViewModel);
        }




        [HttpGet]
        [Route("Perfiles/Eliminar/{id}")]
        public IActionResult EliminarPerfil(int id)
        {
            try
            {
                _perfilLogic.eliminarPerfil(id);
                return RedirectToAction("ImprimirPerfiles");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al eliminar el perfil: " + ex.Message });
            }
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
            return View(rolViewModel);
        }

        [HttpGet]
        [Route("Rol/Editar/{id}")]
        public IActionResult EditarRol(int id)
        {
            try
            {
                var rolModel = _rolLogic.buscarRolPorId(id);

                var rolViewModel = new RolViewModel
                {
                    IdRol = rolModel.IdRol,
                    NombreRol = rolModel.NombreRol,
                    DescripcionRol = rolModel.DescripcionRol
                };

                return View(rolViewModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error al buscar el rol: " + ex.Message);
                return RedirectToAction("ImprimirRoles");
            }
        }

        [HttpPost]
        [Route("Rol/Editar/{id}")]
        public IActionResult EditarRol(int id, [FromForm] RolViewModel rolViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var rolModel = new C1ModelRol
                    {
                        IdRol = rolViewModel.IdRol,
                        NombreRol = rolViewModel.NombreRol,
                        DescripcionRol = rolViewModel.DescripcionRol
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

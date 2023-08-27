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
        private readonly C3BusinessLogicFactura _facturaLogic;
        private readonly C3BusinessLogicEspecialidad _especialidadLogic;
        private readonly C3BusinessLogicMedico _medicoLogic;


        public AdministradorController(C3BusinessLogicUsuario usuarioLogic, C3BusinessLogicRol rolLogic, C3BusinessLogicPerfil perfilLogic, C3BusinessLogicFactura facturaLogic, C3BusinessLogicEspecialidad especialidadLogic, C3BusinessLogicMedico medicoLogic)
        {
            _usuarioLogic = usuarioLogic;
            _rolLogic = rolLogic;
            _perfilLogic = perfilLogic;
            _facturaLogic = facturaLogic;
            _especialidadLogic = especialidadLogic;
            _medicoLogic = medicoLogic;
        }


        [HttpGet]
        [Route("ImprimirEspecialidades")]
        public IActionResult ImprimirEspecialidades()
        {
            try
            {
                var especialidades = _especialidadLogic.imprimirEspecialidad();
                var viewModelList = especialidades.Select(r => new EspecialidadViewModel
                {
                    IdEspecialidad = r.IdEspecialidad,
                    DescripcionEspecialidad = r.DescripcionEspecialidad,
                    PrecioEspecialidad = r.PrecioEspecialidad,
                }).ToList();

                return View(viewModelList);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener los esepcialidades: " + ex.Message });
            }

        }

        [HttpGet]
        [Route("CrearEspecialidad")]
        public IActionResult CrearEspecialidad()
        {
            return View();
        }

        [HttpPost]
        [Route("CrearEspecialidad")]
        public IActionResult CrearEspecialidad([FromForm] EspecialidadViewModel especialidadViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var especialidadModel = new C1ModelEspecialidad
                    {
                        DescripcionEspecialidad = especialidadViewModel.DescripcionEspecialidad,
                        PrecioEspecialidad = especialidadViewModel.PrecioEspecialidad,
                    };
                    _especialidadLogic.insertarEspecialidad(especialidadModel);
                    return RedirectToAction("ImprimirEspecialidades");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Error al crear el rol: " + ex.Message);
                }
            }
            return View(especialidadViewModel);
        }

        [HttpGet]
        [Route("Especialidad/Editar/{id}")]
        public IActionResult EditarEspecialidad(int id)
        {
            try
            {
                var especialdiadaModel = _especialidadLogic.buscarEspecialidadPorId(id);

                var especialidadViewModel = new EspecialidadViewModel
                {
                    IdEspecialidad = especialdiadaModel.IdEspecialidad,
                    DescripcionEspecialidad = especialdiadaModel.DescripcionEspecialidad,
                    PrecioEspecialidad = especialdiadaModel.PrecioEspecialidad,
                };

                return View(especialidadViewModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error al buscar la especialidad: " + ex.Message);
                return RedirectToAction("ImprimirEspecialidades");
            }
        }

        [HttpPost]
        [Route("Especialidad/Editar/{id}")]
        public IActionResult EditarEspecialidad(int id, [FromForm] EspecialidadViewModel especialidadViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var especialdiadaModel = new C1ModelEspecialidad
                    {
                        IdEspecialidad = especialidadViewModel.IdEspecialidad,
                        DescripcionEspecialidad = especialidadViewModel.DescripcionEspecialidad,
                        PrecioEspecialidad = especialidadViewModel.PrecioEspecialidad
                    };

                    _especialidadLogic.actualizarEspecialidad(especialdiadaModel);

                    return RedirectToAction("ImprimirEspecialidades");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Error al actualizar la especialidad: " + ex.Message);
                }
            }

            return View(especialidadViewModel);
        }

        [HttpGet]
        [Route("EliminarEspecialidad/{id}")]
        public IActionResult EliminarEspecialidad(int id)
        {
            try
            {
                _especialidadLogic.eliminarEspecialidad(id);

                return RedirectToAction("ImprimirEspecialidades");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al eliminar la especialidad: " + ex.Message });
            }
        }
    



    [HttpGet]
        [Route("ImprimirMedicos")]
        public IActionResult ImprimirMedicos()
        {
            try
            {
                var medicos = _medicoLogic.obtenerMedicoEspecialidadEager();
                var viewModelList = medicos.Select(m => new MedicoViewModel
                {
                    IdMedico = m.IdMedico,
                    NombreMedico = m.NombreMedico,
                    ApellidoMedico = m.ApellidoMedico,
                    TelefonoMedico = m.TelefonoMedico,
                    CorreoMedico = m.CorreoMedico,
                    HorarioMedico = m.HorarioMedico,
                    IdEspecialidad = m.C1ModelEspecialidad.IdEspecialidad,
                    DescripcionEspecialidad = m.C1ModelEspecialidad.DescripcionEspecialidad // Asignar la descripción de la especialidad
                }).ToList();

                return View(viewModelList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener los médicos: " + ex.Message });
            }
        }

        [HttpGet]
        [Route("CrearMedico")]
        public IActionResult CrearMedico()
        {
            var especialidades = _especialidadLogic.imprimirEspecialidad();
            ViewBag.Especialidades = new SelectList(especialidades,"IdEspecialidad","DescripcionEspecialidad");
            return View();
        }

        [HttpPost]
        [Route("CrearMedico")]
        public IActionResult CrearMedico([FromForm] MedicoViewModel medicoViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var medicoModel = new C1ModelMedico
                    {
                        NombreMedico = medicoViewModel.NombreMedico,
                        ApellidoMedico = medicoViewModel.ApellidoMedico,
                        TelefonoMedico = medicoViewModel.TelefonoMedico,
                        CorreoMedico = medicoViewModel.CorreoMedico,
                        HorarioMedico = medicoViewModel.HorarioMedico,
                        IdEspecialidad = medicoViewModel.IdEspecialidad
                    };

                    _medicoLogic.insertarMedico(medicoModel);
                    return RedirectToAction("ImprimirMedicos");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Error al crear el médico: " + ex.Message);
                }
            }
            // Obtén nuevamente la lista de roles disponibles y agrégala a la ViewBag
            ViewBag.Especialidades = new SelectList(_especialidadLogic.imprimirEspecialidad(), "IdEspecialidad", "DescripcionEspecialidad");
            return View(medicoViewModel);
        }

        [HttpGet]
        [Route("Editar Medico/Editar/{id}")]
        public IActionResult EditarMedico(int id)
        {
            try
            {
                var medicoModel = _medicoLogic.buscarMedicoPorId(id);
                var especialidades = _especialidadLogic.imprimirEspecialidad();

                var medicoViewModel = new MedicoViewModel
                {
                    IdMedico = medicoModel.IdMedico,
                    NombreMedico = medicoModel.NombreMedico,
                    ApellidoMedico = medicoModel.ApellidoMedico,
                    TelefonoMedico = medicoModel.TelefonoMedico,
                    CorreoMedico = medicoModel.CorreoMedico,
                    HorarioMedico = medicoModel.HorarioMedico,
                    IdEspecialidad = medicoModel.IdEspecialidad
                };

                ViewBag.Especialidades = new SelectList(especialidades, "IdEspecialidad", "DescripcionEspecialidad", medicoViewModel.IdEspecialidad);
                return View(medicoViewModel);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error al buscar el médico: " + ex.Message);
                return RedirectToPage("ImprimirMedicos");
            }

        }

        [HttpPost]
        [Route("Editar Medico/Editar/{id}")]
        public IActionResult EditarMedico(int id, [FromForm] MedicoViewModel medicoViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var medicoModel = new C1ModelMedico
                    {
                        IdMedico = medicoViewModel.IdMedico,
                        NombreMedico = medicoViewModel.NombreMedico,
                        ApellidoMedico = medicoViewModel.ApellidoMedico,
                        TelefonoMedico = medicoViewModel.TelefonoMedico,
                        CorreoMedico = medicoViewModel.CorreoMedico,
                        HorarioMedico = medicoViewModel.HorarioMedico,
                        IdEspecialidad = medicoViewModel.IdEspecialidad
                    };

                    _medicoLogic.actualizarMedico(medicoModel);
                    return RedirectToAction("ImprimirMedicos");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Error al actualizar el perfil: " + ex.Message);
                }
            }

            // Obtén nuevamente la lista de roles disponibles y agrégala a la ViewBag
            ViewBag.Especialidades = new SelectList(_especialidadLogic.imprimirEspecialidad(), "IdEspecialidad", "DescripcionEspecialidad");
            return View(medicoViewModel);
        }

        [HttpGet]
        public IActionResult EliminarMedico(int id)
        {
            try
            {
                _medicoLogic.eliminarMedico(id);
                return RedirectToAction("ImprimirMedicos");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al eliminar el médico: " + ex.Message });
            }
        }


        [HttpGet]
        [Route("GraficoMedicosPorEspecialidad")]
        public IActionResult GraficoMedicosPorEspecialidad()
        {
            try
            {
                var medicosPorEspecialidad = _medicoLogic.ObtenerNumeroMedicosPorEspecialidad();
                var viewModel = new MedicosPorEspecialidadViewModel
                {
                    Especialidades = medicosPorEspecialidad.Keys.ToList(),
                    NumeroMedicos = medicosPorEspecialidad.Values.ToList()
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener el número de médicos por especialidad: " + ex.Message });
            }
        }



        [HttpGet]
        [Route("GananciasMensuales")]
        public IActionResult GananciasMensuales()
        {
            try
            {
                // Obtener las facturas y sumar las ganancias por mes
                var facturas = _facturaLogic.imprimirFacturas();
                var gananciasPorMes = new decimal[12];

                foreach (var factura in facturas)
                {
                    int mes = factura.FechaFactura.Month;
                    gananciasPorMes[mes - 1] += factura.MontoTotalFctura;
                }

                var viewModel = new GananciasMensualesViewModel
                {
                    Meses = Enumerable.Range(1, 12).ToList(),
                    Ganancias = gananciasPorMes.ToList()
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener los datos del reporte: " + ex.Message });
            }
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

        //[HttpGet]
        //[Route("ImprimirUsuarios")]
        //public IActionResult ImprimirUsuarios()
        //{
        //    try
        //    {
        //        var usuarios = _usuarioLogic.imprimirUsuario();
        //        var viewModelList = usuarios.Select(r => new UsuarioViewModel
        //        {
        //            id = r.IdRol,
        //            NombreRol = r.NombreRol,
        //            DescripcionRol = r.DescripcionRol,
        //        }).ToList();

        //        return View(viewModelList);

        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { message = "Error al obtener los roles: " + ex.Message });
        //    }

        //}

        //[HttpGet]
        //[Route("CrearRol")]
        //public IActionResult CrearRol()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[Route("CrearRol")]
        //public IActionResult CrearRol([FromForm] RolViewModel rolViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var rolModel = new C1ModelRol
        //            {
        //                NombreRol = rolViewModel.NombreRol,
        //                DescripcionRol = rolViewModel.DescripcionRol,
        //            };
        //            _rolLogic.insertarRol(rolModel);
        //            return RedirectToAction("ImprimirRoles");
        //        }
        //        catch (Exception ex)
        //        {
        //            ModelState.AddModelError(string.Empty, "Error al crear el rol: " + ex.Message);
        //        }
        //    }
        //    return View(rolViewModel);
        //}

        //[HttpGet]
        //[Route("Rol/Editar/{id}")]
        //public IActionResult EditarRol(int id)
        //{
        //    try
        //    {
        //        var rolModel = _rolLogic.buscarRolPorId(id);

        //        var rolViewModel = new RolViewModel
        //        {
        //            IdRol = rolModel.IdRol,
        //            NombreRol = rolModel.NombreRol,
        //            DescripcionRol = rolModel.DescripcionRol
        //        };

        //        return View(rolViewModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError(string.Empty, "Error al buscar el rol: " + ex.Message);
        //        return RedirectToAction("ImprimirRoles");
        //    }
        //}

        //[HttpPost]
        //[Route("Rol/Editar/{id}")]
        //public IActionResult EditarRol(int id, [FromForm] RolViewModel rolViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var rolModel = new C1ModelRol
        //            {
        //                IdRol = rolViewModel.IdRol,
        //                NombreRol = rolViewModel.NombreRol,
        //                DescripcionRol = rolViewModel.DescripcionRol
        //            };

        //            _rolLogic.actualizarRol(rolModel);

        //            return RedirectToAction("ImprimirRoles");
        //        }
        //        catch (Exception ex)
        //        {
        //            ModelState.AddModelError(string.Empty, "Error al actualizar el rol: " + ex.Message);
        //        }
        //    }

        //    return View(rolViewModel);
        //}

        //[HttpGet]
        //[Route("EliminarRol/{id}")]
        //public IActionResult EliminarRol(int id)
        //{
        //    try
        //    {
        //        _rolLogic.eliminarRol(id);

        //        return RedirectToAction("ImprimirRoles");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { message = "Error al eliminar el rol: " + ex.Message });
        //    }
        //}
    }
}

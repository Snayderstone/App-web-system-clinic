using AppWebSistemaClinica.C3BusinessLogic;
using AppWebSistemaClinica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppWebSistemaClinica.C1Model;

namespace AppWebSistemaClinica.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class UsuarioController : Controller
    {

        private readonly C3BusinessLogicUsuario _usuarioLogic;

        public UsuarioController(C3BusinessLogicUsuario usuarioLogic)
        {
            _usuarioLogic = usuarioLogic;
        }

        [HttpGet]
        [Route("ImprimirUsuarios")]
        public IActionResult ImprimirUsuarios()
        {
            try
            {
                var usuarios = _usuarioLogic.imprimirUsuario();
                var viewModelList = usuarios.Select(c => new UsuarioViewModel
                {
                    IdUsuario = c.IdUsuario,
                    NombreUsuario = c.NombreUsuario,
                    ContrasenaUsuario = c.ContrasenaUsuario,
                }).ToList();

                return View(viewModelList); // Retornar la vista
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener los clientes: " + ex.Message });
            }

        }

        [HttpPost]
        [Route("RegistrarUsuario")]
        public IActionResult RegistrarUsuario(UsuarioViewModel usuarioViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var nuevoUsuario = new C1ModelUsuario
                    {
                        NombreUsuario = usuarioViewModel.NombreUsuario,
                        ContrasenaUsuario = usuarioViewModel.ContrasenaUsuario,
                        
                    };

                    _usuarioLogic.insertarUsuario(nuevoUsuario);

                    return StatusCode(201); // Retornar un código de estado 201 (Created)
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al crear el cliente: " + ex.Message });
            }
        }

        [HttpPut]
        [Route("ActualizarUsuario")]
        public IActionResult ActualizarUsuario(UsuarioViewModel usuarioViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuarioExistente = new C1ModelUsuario
                    {
                        IdUsuario = usuarioViewModel.IdUsuario,
                        NombreUsuario = usuarioViewModel.NombreUsuario,
                        ContrasenaUsuario = usuarioViewModel.ContrasenaUsuario,
                    };

                    _usuarioLogic.actualizarUsuario(usuarioExistente);

                    return Ok(new { message = "Usuario actualizado exitosamente." });
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al actualizar el usuario: " + ex.Message });
            }
        }

        [HttpDelete]
        [Route("EliminarUsuario/{id}")]
        public IActionResult EliminarUsuario(int id)
        {
            try
            {
                _usuarioLogic.eliminarUsuario(id);
                return Ok(new { message = "Usuario eliminado exitosamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al eliminar el usuario: " + ex.Message });
            }
        }
     
        public IActionResult Index()
        {
            return View();
        }
    }
}
    


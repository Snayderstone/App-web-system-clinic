using AppWebSistemaClinica.C3BusinessLogic;
using AppWebSistemaClinica.Models;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Index()
        {
            return View();
        }
    }
}

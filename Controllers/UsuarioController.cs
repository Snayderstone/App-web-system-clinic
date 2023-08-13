using AppWebSistemaClinica.C3BusinessLogic;
using AppWebSistemaClinica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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


    


    

        public IActionResult Index()
        {
            return View();
        }
    }
}

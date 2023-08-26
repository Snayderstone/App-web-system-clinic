using AppWebSistemaClinica.Controllers;
using System.ComponentModel.DataAnnotations;

namespace AppWebSistemaClinica.Models
{
    public class PerfilViewModel
    {

        public int IdPerfil { get; set; }
        
        public int IdUsuario { get; set; }
        
        public string NombreUsuario { get; set; }
        
        public string ApellidoUsuario { get; set; }
        
        public string CorreoElectronico { get; set; }
        
        public int IdRol { get; set; }
        
        public string NombreRol { get; set; }
        
        public string DescripcionRol { get; set; }
    }
}
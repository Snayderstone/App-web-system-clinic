using AppWebSistemaClinica.Controllers;
using System.ComponentModel.DataAnnotations;

namespace AppWebSistemaClinica.Models
{
    public class AccesoViewModel
    {
        public int IdUsuario { get; set; }
        
        public string NombreUsuario { get; set; }
        public string ApellidoUsuario { get; set; }

        [Required(ErrorMessage = "El correo electrónico es requerido.")]
        [EmailAddress(ErrorMessage = "No es un correo electrónico váldo.")]
        [UniqueEmail(ErrorMessage = "Este correo electrónico no existe.")]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "Escriba la contraseña")]
        [UniqueEmail(ErrorMessage = "Contraseña incorrecta")]
        [DataType(DataType.Password)]
        public string ContrasenaUsuario { get; set; }
    }
}

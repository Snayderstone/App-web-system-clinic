using AppWebSistemaClinica.Controllers;
using System.ComponentModel.DataAnnotations;

namespace AppWebSistemaClinica.Models
{
    public class AccesoViewModel
    {

        //public int IdPerfil { get; set; }
        //public int IdUsuario { get; set; }
        //public int IdRol { get; set; }
        //public string NombreUsuario { get; set; }
        //public string ApellidoUsuario { get; set; }

        //[Required(ErrorMessage = "El correo electrónico es requerido.")]
        //[EmailAddress(ErrorMessage = "No es un correo electrónico váldo.")]
        //[ValidarCorreoExiste(ErrorMessage = "Este correo electrónico no existe.")]
        //public string CorreoElectronico { get; set; }

        //public string ContrasenaHashAlmacenada { get; set; } // Nuevo campo para el hash de contraseña almacenado en la base de datos

        //[Required(ErrorMessage = "La contraseña es requerida")]
        //[DataType(DataType.Password)]
        ////[ValidarContrasenaCorrecta(ErrorMessage = "Contraseña incorrecta")]
        //public string ContrasenaUsuario { get; set; } no poner las valdiaciones que interactuan con la bisness logic

        [Required(ErrorMessage = "El correo electrónico es requerido.")]
        [EmailAddress(ErrorMessage = "Ingresa una dirección de correo electrónico válida.")]
        [ValidarCorreoExiste(ErrorMessage = "Este correo electrónico no existe.")]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida.")]
        [ValidarContrasenaCorrecta(ErrorMessage = "Contraseña incorrecta.")]
        [DataType(DataType.Password)]
        public string ContrasenaUsuario { get; set; }
    }
}

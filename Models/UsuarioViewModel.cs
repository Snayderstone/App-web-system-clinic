using AppWebSistemaClinica.Controllers;
using System.ComponentModel.DataAnnotations;

namespace AppWebSistemaClinica.Models
{
    public class UsuarioViewModel
    {

        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es requerido.")]
        [StringLength(20, ErrorMessage = "El nombre de usuario no puede tener más de 20 caracteres.")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "El apellido de usuario es requerido.")]
        [StringLength(50, ErrorMessage = "El apellido de usuario no puede tener más de 50 caracteres.")]
        public string ApellidoUsuario { get; set; }

        [Required(ErrorMessage = "El correo electrónico es requerido.")]
        [EmailAddress(ErrorMessage = "El campo debe ser una dirección de correo electrónico válida.")]
        [UniqueEmail(ErrorMessage = "Este correo electrónico ya está en uso.")]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida.")]
        [StringLength(50, ErrorMessage = "La contraseña no puede tener más de 50 caracteres.")]
        [RegularExpression(@"^(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?=.*[@#$%^&+=]).{8,}$",
        ErrorMessage = "La contraseña debe tener al menos 8 caracteres, incluyendo al menos una letra mayúscula, una letra minúscula, un número y un carácter especial.")]
        [DataType(DataType.Password)]
        public string ContrasenaUsuario { get; set; }

        [Required(ErrorMessage = "Confirmación de contraseña requerida.")]
        [Compare("ContrasenaUsuario", ErrorMessage = "La contraseña no coincide.")]
        [DataType(DataType.Password)]
        [Display(Name = "Repita la contraseña")]
        public string ConfirmacionContrasena { get; set; }

        public UsuarioViewModel()
        {
        }

        public UsuarioViewModel(int idUsuario, string nombreUsuario, string apellidoUsuario, string correoElectronico, string contrasenaUsuario)
        {
            IdUsuario = idUsuario;
            NombreUsuario = nombreUsuario;
            ApellidoUsuario = apellidoUsuario;
            CorreoElectronico = correoElectronico;
            ContrasenaUsuario = contrasenaUsuario;
        }
    }

}

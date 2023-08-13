using System.ComponentModel.DataAnnotations;

namespace AppWebSistemaClinica.Models
{
    public class UsuarioViewModel
    {

        public UsuarioViewModel ()
        {
        }

        public UsuarioViewModel (int idUsuario, string nombreUsuario, string contrasenaUsuario)
        {
            IdUsuario = idUsuario;
            NombreUsuario = nombreUsuario;
            ContrasenaUsuario = contrasenaUsuario;
        }

        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es requerido.")]
        [StringLength(20, ErrorMessage = "El nombre de usuario no puede tener más de 20 caracteres.")]
        [EmailAddress(ErrorMessage = "El campo debe ser una dirección de correo electrónico válida.")]

        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida.")]
        [StringLength(50, ErrorMessage = "La contraseña no puede tener más de 50 caracteres.")]
        [RegularExpression(@"^(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?=.*[@#$%^&+=]).{8,}$",
        ErrorMessage = "La contraseña debe tener al menos 8 caracteres, incluyendo al menos una letra mayúscula, una letra minúscula, un número y un carácter especial.")]
        [DataType(DataType.Password)]

        public string ContrasenaUsuario { get; set; }
    }
}

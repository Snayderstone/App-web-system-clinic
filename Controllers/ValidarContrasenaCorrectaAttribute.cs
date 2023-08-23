using System.ComponentModel.DataAnnotations;
using AppWebSistemaClinica.C3BusinessLogic;

namespace AppWebSistemaClinica.Controllers
{
    public class ValidarContrasenaCorrectaAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var contraseña = value as string;
            var correo = validationContext.ObjectType.GetProperty("CorreoElectronico").GetValue(validationContext.ObjectInstance) as string;

            if (string.IsNullOrWhiteSpace(contraseña)) // Validar si la contraseña está vacía o contiene solo espacios en blanco
            {
                return new ValidationResult("La contraseña no puede estar vacía.");
            }

            var usuarioLogic = (C3BusinessLogicUsuario)validationContext.GetService(typeof(C3BusinessLogicUsuario));
            var usuario = usuarioLogic.buscarUsuarioPorCorreo(correo);

            if (usuario == null || usuario.ContrasenaUsuario != usuarioLogic.GenerarHashContraseña(contraseña))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}

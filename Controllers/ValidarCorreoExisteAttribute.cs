using System.ComponentModel.DataAnnotations;
using AppWebSistemaClinica.C3BusinessLogic;
namespace AppWebSistemaClinica.Controllers
{
    public class ValidarCorreoExisteAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var correo = value as string;

            var usuarioLogic = (C3BusinessLogicUsuario)validationContext.GetService(typeof(C3BusinessLogicUsuario));
            var usuario = usuarioLogic.buscarUsuarioPorCorreo(correo);

            if (usuario == null)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}

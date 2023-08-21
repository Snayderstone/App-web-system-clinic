using AppWebSistemaClinica.C3BusinessLogic;
using System.ComponentModel.DataAnnotations;

namespace AppWebSistemaClinica.Controllers
{
    public class UniqueEmailAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var correoElectronico = value.ToString();
            var usuarioLogic = (C3BusinessLogicUsuario)validationContext.GetService(typeof(C3BusinessLogicUsuario)); // Ajusta según la inyección de dependencias

            var usuarioExistente = usuarioLogic.buscarUsuarioPorCorreo(correoElectronico);

            if (usuarioExistente != null)
            {
                return new ValidationResult("Este correo electrónico ya está en uso.");
            }

            return ValidationResult.Success;
        }
    }
}

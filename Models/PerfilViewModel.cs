using System.ComponentModel.DataAnnotations;

namespace AppWebSistemaClinica.Models
{
    public class PerfilViewModel
    {
        public int IdPerfil { get; set; }

        [Required(ErrorMessage = "El ID de Usuario es requerido.")]
        [Display(Name = "ID de Usuario")]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El ID de Rol es requerido.")]
        [Display(Name = "ID de Rol")]
        public int IdRol { get; set; }
    }
}
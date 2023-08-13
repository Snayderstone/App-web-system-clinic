using System.ComponentModel.DataAnnotations;

namespace AppWebSistemaClinica.Models
{
    public class RolViewModel
    {
        public int IdRol { get; set; }

        [Required(ErrorMessage = "El nombre de rol es requerido.")]
        [StringLength(50, ErrorMessage = "El nombre de rol no puede tener más de 50 caracteres.")]
        public string NombreRol { get; set; }

        [StringLength(200, ErrorMessage = "La descripción de rol no puede tener más de 200 caracteres.")]
        public string DescripcionRol { get; set; }
    }
}
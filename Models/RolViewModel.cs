using AppWebSistemaClinica.Controllers;
using System.ComponentModel.DataAnnotations;

namespace AppWebSistemaClinica.Models
{
    public class RolViewModel
    {

        public int IdRol { get; set; }

        [Required(ErrorMessage = "El Nombre del Rol es obligatorio.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El Nombre del Rol debe tener entre {2} y {1} caracteres.")]
        public string NombreRol { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "La Descripción del Rol debe tener entre {2} y {1} caracteres.")]
        public string DescripcionRol { get; set; }
    }
}
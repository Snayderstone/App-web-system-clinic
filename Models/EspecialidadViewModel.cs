using Microsoft.AspNetCore.Mvc;

using System.ComponentModel.DataAnnotations;

namespace AppWebSistemaClinica.Models
{
    public class EspecialidadViewModel
    {
        public int IdEspecialidad { get; set; }

        [Required(ErrorMessage = "La descripción de la especialidad es requerida.")]
        [StringLength(100, ErrorMessage = "La descripción de la especialidad no puede tener más de 100 caracteres.")]
        [Display(Name = "Descripción de la Especialidad")]
        public string DescripcionEspecialidad { get; set; }

        [Required(ErrorMessage = "El Precio de la especialidad es requerida.")]
        [Display(Name = "Precio de la Especialidad")]
        public decimal PrecioEspecialidad { get; set; }
    }
}

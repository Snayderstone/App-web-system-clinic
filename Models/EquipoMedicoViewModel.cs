using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppWebSistemaClinica.Models
{
    public class EquipoMedicoViewModel
    {
        public int IdEquipoMedico { get; set; }

        [Required(ErrorMessage = "El nombre del equipo médico es requerido.")]
        [StringLength(100, ErrorMessage = "El nombre del equipo médico no puede tener más de 100 caracteres.")]
        [Display(Name = "Nombre del Equipo Médico")]
        public string NombreEquipoMedico { get; set; }

        [StringLength(200, ErrorMessage = "La descripción del equipo médico no puede tener más de 200 caracteres.")]
        [Display(Name = "Descripción del Equipo Médico")]
        public string DescripcionEquipoMedico { get; set; }

        // Puedes incluir propiedades adicionales según tus necesidades.

        public ICollection<EquipoMedicoClinicaViewModel> C1ModelEquipoMedicoClinica { get; set; } = new List<EquipoMedicoClinicaViewModel>();
    }
}
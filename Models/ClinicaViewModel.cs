using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppWebSistemaClinica.Models
{
    public class ClinicaViewModel
    {
        public int IdClinica { get; set; }

        [Required(ErrorMessage = "El nombre de la clínica es requerido.")]
        [Display(Name = "Nombre de la Clínica")]
        public string NombreClinica { get; set; }

        [Required(ErrorMessage = "La capacidad de la clínica es requerida.")]
        [Display(Name = "Capacidad de la Clínica")]
        public int CapacidadClinica { get; set; }

        [Required(ErrorMessage = "La ubicación de la clínica es requerida.")]
        [Display(Name = "Ubicación de la Clínica")]
        public string UbicacionClinica { get; set; }

        [Required(ErrorMessage = "El precio de consulta de la clínica es requerido.")]
        [Display(Name = "Precio de Consulta de la Clínica")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser un valor positivo.")]
        public decimal PrecioConsultaClinica { get; set; }

        [Required(ErrorMessage = "El médico es requerido.")]
        [Display(Name = "Médico")]
        public int IdMedico { get; set; }

        public ICollection<EquipoMedicoClinicaViewModel> EquipoMedicoClinica { get; set; } = new List<EquipoMedicoClinicaViewModel>();
    }

    public class EquipoMedicoClinicaViewModel
    {
        public int IdEquipoMedico { get; set; }
        public string NombreEquipoMedico { get; set; }
        // Puedes agregar más propiedades según el modelo C1ModelEquipoMedicoClinica si es necesario
    }
}
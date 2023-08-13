using System;
using System.ComponentModel.DataAnnotations;

namespace AppWebSistemaClinica.Models
{
    public class CitaViewModel
    {
        public int IdCita { get; set; }

        [Required(ErrorMessage = "La fecha de cita es requerida.")]
        [Display(Name = "Fecha de Cita")]
        public DateTime FechaCita { get; set; }

        [Required(ErrorMessage = "La hora de inicio de cita es requerida.")]
        [Display(Name = "Hora de Inicio")]
        public DateTime HoraInicioCita { get; set; }

        [Required(ErrorMessage = "La hora de fin de cita es requerida.")]
        [Display(Name = "Hora de Fin")]
        public DateTime HoraFinCita { get; set; }

        [Required(ErrorMessage = "El estado de cita es requerido.")]
        [Display(Name = "Estado de Cita")]
        public string EstadoCita { get; set; }

        [Required(ErrorMessage = "El médico es requerido.")]
        [Display(Name = "Médico")]
        public int IdMedico { get; set; }

        [Required(ErrorMessage = "El detalle de factura es requerido.")]
        [Display(Name = "Detalle de Factura")]
        public int IdDetalleFactura { get; set; }

        [Required(ErrorMessage = "El paciente es requerido.")]
        [Display(Name = "Paciente")]
        public int IdPaciente { get; set; }
    }
}
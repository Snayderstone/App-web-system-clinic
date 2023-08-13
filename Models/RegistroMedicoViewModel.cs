using System.ComponentModel.DataAnnotations;

namespace AppWebSistemaClinica.Models
{
    public class RegistroMedicoViewModel
    {
        public int IdRegistroMedico { get; set; }

        [Required(ErrorMessage = "Los detalles del registro médico son requeridos.")]
        [Display(Name = "Detalles del Registro Médico")]
        public string DetallesRegistroMedico { get; set; }

        [Required(ErrorMessage = "La historia clínica es requerida.")]
        [Display(Name = "Historia Clínica")]
        public int HistoriaClinica { get; set; }
    }
}
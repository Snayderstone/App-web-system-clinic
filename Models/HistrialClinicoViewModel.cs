using System.ComponentModel.DataAnnotations;

namespace AppWebSistemaClinica.Models
{
    public class HistorialClinicoViewModel
    {
        public int Id_HistorialClinico { get; set; }

        [Required(ErrorMessage = "La descripción del historial clínico es requerida.")]
        [Display(Name = "Descripción del Historial Clínico")]
        public string DescripcionHisClinico { get; set; }

        [Display(Name = "Notas Médicas del Historial Clínico")]
        public string NotasMedicasHisClinico { get; set; }

        [Display(Name = "Lista de Enfermedades Recientes del Historial Clínico")]
        public string ListEnfermedadesRecientHisClinico { get; set; }

        [Required(ErrorMessage = "El paciente es requerido.")]
        [Display(Name = "Paciente")]
        public int IdPaciente { get; set; }
    }
}
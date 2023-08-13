using System.ComponentModel.DataAnnotations;

namespace AppWebSistemaClinica.Models
{
    public class MedicoViewModel
    {
        public int IdMedico { get; set; }

        [Required(ErrorMessage = "El nombre del médico es requerido.")]
        [Display(Name = "Nombre del Médico")]
        public string NombreMedico { get; set; }

        [Required(ErrorMessage = "El apellido del médico es requerido.")]
        [Display(Name = "Apellido del Médico")]
        public string ApellidoMedico { get; set; }

        [Required(ErrorMessage = "El teléfono del médico es requerido.")]
        [Display(Name = "Teléfono del Médico")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El teléfono debe tener 10 dígitos.")]
        public int TelefonoMedico { get; set; }

        [Required(ErrorMessage = "El correo electrónico del médico es requerido.")]
        [Display(Name = "Correo Electrónico del Médico")]
        [EmailAddress(ErrorMessage = "El campo debe ser una dirección de correo electrónico válida.")]
        public string CorreoMedico { get; set; }

        [Required(ErrorMessage = "El horario del médico es requerido.")]
        [Display(Name = "Horario del Médico")]
        public string HorarioMedico { get; set; }

        [Required(ErrorMessage = "La especialidad del médico es requerida.")]
        [Display(Name = "Especialidad del Médico")]
        public int IdEspecialidad { get; set; }
    }
}
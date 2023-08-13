using System;
using System.ComponentModel.DataAnnotations;

namespace AppWebSistemaClinica.Models
{
    public class PacienteViewModel
    {
        public int IdPaciente { get; set; }

        [Required(ErrorMessage = "El nombre del paciente es requerido.")]
        [Display(Name = "Nombre")]
        public string NombrePaciente { get; set; }

        [Required(ErrorMessage = "El apellido del paciente es requerido.")]
        [Display(Name = "Apellido")]
        public string ApellidoPaciente { get; set; }

        [Required(ErrorMessage = "La cédula del paciente es requerida.")]
        [Display(Name = "Cédula")]
        public int CedulaPaciente { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento del paciente es requerida.")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimientoPaciente { get; set; }

        [Required(ErrorMessage = "La edad del paciente es requerida.")]
        [Display(Name = "Edad")]
        public int EdadPaciente { get; set; }

        [Required(ErrorMessage = "El teléfono del paciente es requerido.")]
        [Display(Name = "Teléfono")]
        public int TelefonoPaciente { get; set; }

        [Required(ErrorMessage = "El correo electrónico del paciente es requerido.")]
        [Display(Name = "Correo Electrónico")]
        [EmailAddress(ErrorMessage = "El campo debe ser una dirección de correo electrónico válida.")]
        public string CorreoPaciente { get; set; }

        [Required(ErrorMessage = "El estado civil del paciente es requerido.")]
        [Display(Name = "Estado Civil")]
        public string EstadoCivilPaciente { get; set; }
    }
}

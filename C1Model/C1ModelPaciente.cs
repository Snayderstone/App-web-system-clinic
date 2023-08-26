using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebSistemaClinica.C1Model
{
    [Table("PACIENTES")]
    public class C1ModelPaciente
    {
        [Key]
        public int idPaciente { get; set; }
        public string NombrePaciente { get; set; }
        public string ApellidoPaciente { get; set; }
        public string CedulaPaciente { get; set; }
        public DateTime FechaNacimientoPaciente { get; set; }
        public int EdadPaciente { get; set; }
        public string TelefonoPaciente { get; set;}
        public string CorreoPaciente { get; set; }
        public string EstadoCivilPaciente { get; set; }

        [Required]
        public virtual ICollection<C1ModelFactura> C1ModelFactura { get; set; }

        [Required]
        public virtual ICollection<C1ModelHistorialClinico> C1ModelHistorialClinico { get; set; }

    }
}

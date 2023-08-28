using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebSistemaClinica.C1Model
{
    [Table("MEDICOS")]
    public class C1ModelMedico
    {
        [Key]
        public int IdMedico { get; set; }
        public string NombreMedico { get; set; }
        public string ApellidoMedico { get; set; }
        public string TelefonoMedico { get; set; }
        public string CorreoMedico { get; set; }
        public string HorarioMedico { get; set; }

        [ForeignKey("C1ModelEspecialidad")]
        public int IdEspecialidad { get; set; }
        public virtual C1ModelEspecialidad C1ModelEspecialidad { get; set; }
    }
}

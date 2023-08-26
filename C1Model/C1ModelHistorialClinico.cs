using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppWebSistemaClinica.C1Model
{
    [Table("HISTORIALESCLINICOS")]
    public class C1ModelHistorialClinico
    {
        [Key]
        public int Id_HistorialClinico { get; set; }
        public string DescripcionHisClinico { get; set; }
        public string NotasMedicasHisClinico { get; set; }
        public string ListEnfermedadesRecientHisClinico { get; set; }

        [ForeignKey("C1ModelPaciente")]
        public int IdPaciente { get; set; }
        public virtual C1ModelPaciente C1ModelPaciente { get; set; }

        [Required]
        public virtual ICollection<C1ModelRegistroMedico> C1ModelRegistroMedico { get; set; }

    }
}

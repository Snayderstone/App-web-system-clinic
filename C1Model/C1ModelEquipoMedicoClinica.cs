using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppWebSistemaClinica.C1Model
{
    [Table("EQUIPOSMEDICOSCLINICAS")]
    public class C1ModelEquipoMedicoClinica
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("C1ModelEquipoMedico")]
        public int IdEquipoMedico { get; set; }
        public virtual C1ModelEquipoMedico? C1ModelEquipoMedico { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("C1ModelClinica")]
        public int IdClinica { get; set; }
        public virtual C1ModelClinica? C1ModelClinica { get; set; }

    }
}

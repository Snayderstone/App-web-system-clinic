using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebSistemaClinica.C1Model
{
    [Table ("CITAS")]
    public class C1ModelCita
    {
        [Key]
        public int IdCita { get; set; }
        public DateTime FechaCita { get; set; }
        public DateTime HoraInicioCita { get; set; }
        public DateTime HoraFinCita { get; set; }
        public string EstadoCita { get; set; }

        [ForeignKey("C1ModelMedico")]
        public int IdMedico { get; set; }
        public virtual C1ModelMedico C1ModelMedico { get; set; }

        [ForeignKey("C1ModelClinica")]
        public int IdClinica { get; set; }
        public virtual C1ModelClinica C1ModelClinica { get; set; }

        [Required]
        public virtual ICollection<C1ModelDetalleFactura> C1ModelDetalleFactura { get; set; }  

    }
}

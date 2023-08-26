using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppWebSistemaClinica.C1Model
{
    [Table("FACTURAS")]
    public class C1ModelFactura
    {
        [Key]
        public int IdFactura { get; set; }
        public decimal MontoTotalFctura { get; set; }
        public string EstadoPagoFactura { get; set; }
        public DateTime FechaFactura { get; set; }

        [ForeignKey("C1ModelPaciente")]
        public int IdPaciente { get; set; }
        public virtual C1ModelPaciente C1ModelPaciente { get; set; }

        [ForeignKey("C1ModelPago")]
        public int IdPago { get; set; }
        public virtual C1ModelPago C1ModelPago { get; set; }

        [Required]
        public virtual ICollection<C1ModelDetalleFactura> C1ModelDetalleFactura { get; set; }      


    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinalGrupal.C1Model
{
    [Table("FACTURAS")]
    public class C1ModelFactura
    {
        [Key]
        public int IdFactura { get; set; }
        public decimal MontoTotalFctura { get; set; }
        public string EstadoPagoFactura { get; set; }
        public DateTime FechaFactura { get; set; }

        [ForeignKey("C1ModelDetalleFactura")]
        public int IdDetalleFactura { get; set; }
        public virtual C1ModelDetalleFactura? C1ModelDetalleFactura { get; set; }

    }
}

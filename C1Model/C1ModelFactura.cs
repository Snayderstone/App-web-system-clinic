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

        [Required]
        public virtual ICollection<C1ModelDetalleFactura> C1ModelDetalleFacturas { get; set; }      

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebSistemaClinica.C1Model
{
    [Table("DETALLESFACTURAS")]
    public class C1ModelDetalleFactura
    {
        [Key]
        public int IdDetalleFactura { get; set; }
        public string DescripcionDetalleFactura { get; set; }
        public decimal PrecioUnitarioDetalleFactura { get; set; }
        public decimal IvaDetalleFactura { get; set; }
        public decimal OtroImpuesto { get; set; }
        public decimal PrecioTotalDetalleFactura { get; set; }

        [ForeignKey("C1ModelCita")]
        public int IdCita{ get; set; }
        public virtual C1ModelCita C1ModelCita { get; set; }

        [ForeignKey("C1ModelFactura")]
        public int IdFactura { get; set; }
        public virtual C1ModelFactura C1ModelFactura { get; set; }


    }
}

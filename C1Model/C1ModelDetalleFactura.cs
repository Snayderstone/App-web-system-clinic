using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalGrupal.C1Model
{
    [Table("DETALLESFACTURAS")]
    public class C1ModelDetalleFactura
    {
        [Key]
        public int IdDetalleFactura { get; set; }
        public string DescripcionDetalleFactura { get; set; }
        public int CantidadCitasDetalleFactura { get; set; }
        public decimal PrecioUnitarioDetalleFactura { get; set; }
        public decimal PrecioTotalDetalleFactura { get; set; }

        [ForeignKey("C1ModelPago")]
        public int IdPago { get; set; }
        public virtual C1ModelPago? C1ModelPago { get; set; }

        [Required]
        public virtual ICollection<C1ModelCita> C1ModelCita { get; set; }   

 
    }
}

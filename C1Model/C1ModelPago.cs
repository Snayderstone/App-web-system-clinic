using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebSistemaClinica.C1Model
{
    [Table("PAGOS")]
    public class C1ModelPago
    {
        [Key] 
        public int IdPago { get; set; }
        public string FormaPago { get; set; }
        public string DescripcionPago { get; set; }

        [Required]
        public virtual ICollection<C1ModelFactura> C1ModelFactura { get; set; }
    }
}

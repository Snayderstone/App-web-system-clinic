using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalGrupal.C1Model
{
    [Table("PAGOS")]
    public class C1ModelPago
    {
        [Key] 
        public int IdPago { get; set; }
        public string FormaPago { get; set; }
        public string DescripcionPago { get; set; }
    }
}

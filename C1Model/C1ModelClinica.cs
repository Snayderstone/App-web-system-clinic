using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebSistemaClinica.C1Model
{
    [Table("CLINICAS")]
    public class C1ModelClinica
    {
        [Key]
        public int IdClinica { get; set; }
        public string NombreClinica { get; set; }
        public int CapacidadClinica { get; set; }
        public string UbicacionClinica { get; set; }
        public decimal PrecioConsultaClinica { get; set; }

        [Required]
        public virtual ICollection<C1ModelCita> C1ModelCitas { get; set; }

        [Required]
        public virtual ICollection<C1ModelEquipoMedicoClinica> C1ModelEquipoMedicoClinica { get; set; } = new List<C1ModelEquipoMedicoClinica>();

    }
}

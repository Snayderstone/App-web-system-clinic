using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebSistemaClinica.C1Model
{
    [Table("EQUIPOSMEDICOS")]
    public class C1ModelEquipoMedico
    {
        [Key]
        public int IdEquipoMedico { get; set; }
        public string NombreEquipoMedico { get; set; }
        public string DescripcionEquipoMedico { get; set; }

        public virtual ICollection<C1ModelEquipoMedicoClinica> C1ModelEquipoMedicoClinica { get; set; } = new List<C1ModelEquipoMedicoClinica>();   
    }
}

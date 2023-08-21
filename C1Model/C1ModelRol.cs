using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Build.Framework;

namespace AppWebSistemaClinica.C1Model
{
    [Table("ROLES")]
    public class C1ModelRol
    {
        [Key]
        public int IdRol { get; set; }
        public string NombreRol { get; set; }
        public string DescripcionRol { get; set; }
        public virtual ICollection<C1ModelPerfil> C1ModelPerfil { get; set; }
    }
}

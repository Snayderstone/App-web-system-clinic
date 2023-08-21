using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppWebSistemaClinica.C1Model
{
    [Table("PERFILES")]
    public class C1ModelPerfil
    {
        [Key]
        public int IdPerfil { get; set; }

        [ForeignKey("C1ModelUsuario")]
        public int IdUsuario { get; set; }
        public virtual C1ModelUsuario C1ModelUsuario { get; set; }

        [ForeignKey("C1ModelRol")]
        public int IdRol { get; set; }
        public virtual C1ModelRol C1ModelRol { get; set; }


    }
}

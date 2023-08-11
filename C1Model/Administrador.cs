using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabajoFinalGrupal.C1Models
{
    [Table ("Administrados")]
    public class Administrador
    {
        [Key]
        public int Id_Administrador { get; set; }
        public string Descripcion { get; set; }

        [ForeignKey("Persona")]
        public int Id_Persona { get; set; }
        public virtual Persona Persona { get; set; }
    }
}

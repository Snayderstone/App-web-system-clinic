using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabajoFinalGrupal.C1Models
{
    [Table ("Profesion")]
    public class Profesion
    {
        [Key]
        public int Id_Profesion { get; set; }
        public string Titulo { get; set; }
        public string Especialidad { get; set; }
        public string Experiencia { get; set; }

        [ForeignKey ("Persona")]
        public int Id_Persona { get; set; }
        public virtual Persona Persona { get; set; }

    }
}

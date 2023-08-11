using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabajoFinalGrupal.C1Models
{
    [Table ("Paciente")]
    public class Paciente
    {
        [Key]
        public int Id_Paciente { get; set; }

        [ForeignKey ("Persona")]
        public int Id_Persona { get; set; }
        public virtual Persona Persona { get; set; }

        [Required]
        public virtual ICollection<HistorialClinico> HistorialClinico { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabajoFinalGrupal.C1Models
{
    [Table ("Persona")]
    public class Persona
    {
        [Key]
        public int Id_Persona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Contrasena { get; set; }

        [Required]
        public virtual ICollection<Paciente> Paciente { get; set; }

        [Required]
        public virtual ICollection<Profesion> Profesion { get; set; }

        [Required]
        public virtual ICollection<Administrador> Administrador { get; set; }

    }
}

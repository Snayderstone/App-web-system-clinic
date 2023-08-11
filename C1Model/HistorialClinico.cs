using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabajoFinalGrupal.C1Models
{
    [Table ("Historial Clinico")]
    public class HistorialClinico
    {
        [Key]
        public int Id_HisClinico { get; set; }
        public string Descripcion { get; set; }
        public string NotasMedicas { get; set; }
        public string ListEnfermedadesRecient { get; set; }

        [ForeignKey ("Paciente")]
        public int Id_Paciente { get; set; }
        public virtual Paciente Paciente { get; set; }

    }
}

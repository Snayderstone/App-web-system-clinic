using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebSistemaClinica.C1Model
{
    [Table("DIRECCIONCD")]
    public class DireccionCD
    {
        [Key]
        public int Id_Direccion { get; set; }

        [ForeignKey("TipoDireccion")]
        public int Id_TipoDireccion { get; set; }

        [ForeignKey("PACIENTES")]
        public int idPaciente { get; set; }

        [Required]
        [MaxLength(250)]
        public string Calle_Principal { get; set; }

        [MaxLength(200)]
        public string Calle_Secundaria { get; set; }

        [Required]
        [MaxLength(10)]
        public string Num_Casa { get; set; }

        [MaxLength(250)]
        public string Referencia { get; set; }

        [Required]
        [MaxLength(1)]
        public string Estado { get; set; }

        public TipoDireccionCD TipoDireccion { get; set; }

        [Required]
        public virtual TipoDireccionCD TipoDireccionCD { get; set; }
    }
}

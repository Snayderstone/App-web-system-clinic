using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebSistemaClinica.C1Model
{
    [Table ("TIPODIRECCIONCD")]
    public class TipoDireccionCD
    {
        [Key]
        public int Id_TipoDireccion { get; set; }

        [Required]
        [MaxLength(200)]
        public string Descripcion { get; set; }

        [Required]
        [MaxLength(1)]
        public string Estado { get; set; }

        [Required]
        public virtual DireccionCD DireccionCD { get; set; }

    }
}

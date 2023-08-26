using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppWebSistemaClinica.C1Model
{
    [Table ("ESPECIALIDADES")]
    public class C1ModelEspecialidad
    {
        [Key]
        public int IdEspecialidad { get; set; }

        public string DescripcionEspecialidad { get; set; }
        public decimal PrecioEspecialidad { get; set; }

        [Required]
        public virtual ICollection<C1ModelMedico> C1ModelMedico { get; set; }
    }
}

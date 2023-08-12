using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinalGrupal.C1Model
{
    [Table("FUNCIONES")]
    public class C1ModelFuncion
    {
        [Key]
        public int IdFuncion { get; set; }
        public string NombreFuncion { get; set; }
        public string DescripcionFuncion { get; set; }

    }
}

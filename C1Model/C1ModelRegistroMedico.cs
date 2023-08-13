using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppWebSistemaClinica.C1Model
{
    [Table ("REGISTROSMEDICOS")]
    public class C1ModelRegistroMedico
    {
        [Key]
        public int IdRegistroMedico { get; set; }
        public string DetallesRegistroMedico { get; set; }

        [ForeignKey("C1HistorialClinico")]
        public int HistoriaCliente { get; set; }
        public virtual C1ModelHistorialClinico C1ModelHistorialClinico { get; set; }        

    }
}

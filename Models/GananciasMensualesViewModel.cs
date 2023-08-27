using System.ComponentModel.DataAnnotations;

namespace AppWebSistemaClinica.Models
{
    public class GananciasMensualesViewModel
    {

        public List<int> Meses { get; set; }

        public List<decimal> Ganancias { get; set; }
    }
}

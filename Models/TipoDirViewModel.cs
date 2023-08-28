using System.ComponentModel.DataAnnotations;

namespace AppWebSistemaClinica.Models
{
    public class TipoDirViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = " La descipcion es requerida.")]
        public string descripcion { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "La descripción debe tener 1 caracterer.")]
        public string estado { get; set; }
    }
}

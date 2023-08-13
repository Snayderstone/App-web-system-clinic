using System.ComponentModel.DataAnnotations;

namespace AppWebSistemaClinica.Models
{
    public class PagoViewModel
    {
        public int IdPago { get; set; }

        [Required(ErrorMessage = "La forma de pago es requerida.")]
        [StringLength(50, ErrorMessage = "La forma de pago no puede tener más de 50 caracteres.")]
        [Display(Name = "Forma de Pago")]
        public string FormaPago { get; set; }

        [StringLength(100, ErrorMessage = "La descripción del pago no puede tener más de 100 caracteres.")]
        [Display(Name = "Descripción del Pago")]
        public string DescripcionPago { get; set; }
    }
}
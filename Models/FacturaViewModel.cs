using System;
using System.ComponentModel.DataAnnotations;

namespace AppWebSistemaClinica.Models
{
    public class FacturaViewModel
    {
        public int IdFactura { get; set; }

        [Required(ErrorMessage = "El monto total de la factura es requerido.")]
        [Display(Name = "Monto Total")]
        public decimal MontoTotalFctura { get; set; }

        [Required(ErrorMessage = "El estado de pago de la factura es requerido.")]
        [Display(Name = "Estado de Pago")]
        public string EstadoPagoFactura { get; set; }

        [Required(ErrorMessage = "La fecha de la factura es requerida.")]
        [Display(Name = "Fecha de Factura")]
        public DateTime FechaFactura { get; set; }

        [Required(ErrorMessage = "El detalle de la factura es requerido.")]
        [Display(Name = "Detalle de Factura")]
        public int IdDetalleFactura { get; set; }
    }
}
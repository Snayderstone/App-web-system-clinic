using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppWebSistemaClinica.Models
{
    public class DetalleFacturaViewModel
    {
        public int IdDetalleFactura { get; set; }

        [Required(ErrorMessage = "La descripción del detalle es requerida.")]
        [Display(Name = "Descripción")]
        public string DescripcionDetalleFactura { get; set; }

        [Required(ErrorMessage = "La cantidad de citas es requerida.")]
        [Display(Name = "Cantidad de Citas")]
        public int CantidadCitasDetalleFactura { get; set; }

        [Required(ErrorMessage = "El precio unitario es requerido.")]
        [Display(Name = "Precio Unitario")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio unitario debe ser mayor que cero.")]
        public decimal PrecioUnitarioDetalleFactura { get; set; }

        [Required(ErrorMessage = "El precio total es requerido.")]
        [Display(Name = "Precio Total")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio total debe ser mayor que cero.")]
        public decimal PrecioTotalDetalleFactura { get; set; }

        [Required(ErrorMessage = "El pago es requerido.")]
        [Display(Name = "Pago")]
        public int IdPago { get; set; }

        // La siguiente propiedad es opcional, si deseas mantener una lista de citas asociadas en el ViewModel
        public ICollection<CitaViewModel> C1ModelCitas { get; set; }
    }
}
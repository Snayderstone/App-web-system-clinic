using System.ComponentModel.DataAnnotations;

namespace AppWebSistemaClinica.Models
{
    public class FuncionViewModel
    {
        public int IdFuncion { get; set; }

        [Required(ErrorMessage = "El nombre de la función es requerido.")]
        [StringLength(50, ErrorMessage = "El nombre de la función no puede tener más de 50 caracteres.")]
        public string NombreFuncion { get; set; }

        [StringLength(200, ErrorMessage = "La descripción de la función no puede tener más de 200 caracteres.")]
        [Display(Name = "Descripción de la Función")]
        public string DescripcionFuncion { get; set; }
    }
}
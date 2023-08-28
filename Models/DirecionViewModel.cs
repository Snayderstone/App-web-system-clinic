using System.ComponentModel.DataAnnotations;

public class DirecionViewModel
{
    [Required(ErrorMessage = "La cédula es obligatoria.")]
    public string Cedula { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    public string Nombres { get; set; }

    [Required(ErrorMessage = "El apellido es obligatorio.")]
    public string Apellidos { get; set; }

    [Required(ErrorMessage = "La descripción del tipo de dirección es obligatoria.")]
    public string DescripcionTipoDireccion { get; set; }

    [Required(ErrorMessage = "La calle principal es obligatoria.")]
    public string CallePrincipal { get; set; }

    [Required(ErrorMessage = "La calle secundaria es obligatoria.")]
    public string CalleSecundaria { get; set; }

    [Required(ErrorMessage = "El número de casa es obligatorio.")]
    public string NumCasa { get; set; }

    [Required(ErrorMessage = "El estado de la dirección es obligatorio.")]
    public string EstadoDireccion { get; set; }
}

using AppWebSistemaClinica.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AppWebSistemaClinica.Models
{
    public class PerfilViewModel
    {
        public int IdPerfil { get; set; }

        [Required(ErrorMessage = "El Usuario es requerido.")]
        public int IdUsuario { get; set; }

        public string? NombreUsuario { get; set; }

        public string? ApellidoUsuario { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, ingrese una dirección de correo electrónico válida.")]
        public string? CorreoElectronico { get; set; }

        [Required(ErrorMessage = "El Rol es requerido.")]
        public int IdRol { get; set; }

        public string? NombreRol { get; set; }

        public string? DescripcionRol { get; set; }

        // Add SelectList properties for Roles and Correos
        public SelectList? Roles { get; set; }
        public SelectList? Correos { get; set; }
    }
}
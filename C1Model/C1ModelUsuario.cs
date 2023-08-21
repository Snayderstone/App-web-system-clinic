using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebSistemaClinica.C1Model
{
    [Table("USUARIOS")]
    public class C1ModelUsuario
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required]
        public string NombreUsuario { get; set; }
        [Required]
        public string ApellidoUsuario { get; set; }
        [Required]
        public string CorreoElectronico { get; set; }
        [Required]
        public string ContrasenaUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
        [Required]
        public virtual ICollection<C1ModelPerfil> C1ModelPerfil { get; set; }
    }
}

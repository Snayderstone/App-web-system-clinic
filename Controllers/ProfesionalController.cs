using AppWebSistemaClinica.C3BusinessLogic;
using AppWebSistemaClinica.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppWebSistemaClinica.Controllers

{
    [ApiController]
    [Route("Api/[controller]")]
    [SetProfLayout] // Aplicar el atributo personalizado aquí
    public class ProfesionalController : Controller
    {
        private readonly C3BusinessLogicDetalleFactura _detalle;
        private readonly C3BusinessLogicFactura _factura;

        public ProfesionalController(C3BusinessLogicDetalleFactura detalleFactura, C3BusinessLogicFactura factura)
        {
            _detalle = detalleFactura;
            _factura = factura;
        }
        [HttpGet]
        [Route("Index Prof")]
        public IActionResult IndexProf()
        {
            return View();
        }


        [HttpGet]
        [Route("ImprimirRoles")]
        public IActionResult tablapro()
        {
            try
            {
                var detalleFacturas = _detalle.obtenerTodasCitasEgaer();
                var viewModelList = detalleFacturas.Select(r => new DetalleFacturaViewModel 
                {
                 IdDetalleFactura  = r.IdDetalleFactura,
                 IdCita = r.IdCita,
                 NombrePaciente=r.C1ModelFactura.C1ModelPaciente.NombrePaciente,
                 NombreMedico = r.C1ModelCita.C1ModelMedico.NombreMedico,
                 CorreoMedico = r.C1ModelCita.C1ModelMedico.CorreoMedico,
                 NombreClinica = r.C1ModelCita.C1ModelClinica.NombreClinica,
                 DescripcionEspecialidad = r.C1ModelCita.C1ModelMedico.C1ModelEspecialidad.DescripcionEspecialidad,


                }).ToList();

                return View(viewModelList);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener los roles: " + ex.Message });
            }

        }


    }
}

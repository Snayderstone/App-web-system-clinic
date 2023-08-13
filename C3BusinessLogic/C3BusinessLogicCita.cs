using AppWebSistemaClinica.C1Model;
using AppWebSistemaClinica.C2DataAccess.C2AccessGeneric;

namespace AppWebSistemaClinica.C3BusinessLogic
{
    internal class C3BusinessLogicCita
    {
        readonly C2AccessGenericIGeneric<C1ModelCita> modeloCita = new C2AccessGenericGeneric<C1ModelCita>();
        readonly C2AccessGenericIGeneric<C1ModelMedico> modeloMedico = new C2AccessGenericGeneric<C1ModelMedico>();
        readonly C2AccessGenericIGeneric<C1ModelDetalleFactura> modeloDetalleFactura = new C2AccessGenericGeneric<C1ModelDetalleFactura>();
        readonly C2AccessGenericIGeneric<C1ModelPaciente> modeloPaciente = new C2AccessGenericGeneric<C1ModelPaciente>();

        public void crearCita (C1ModelCita idCita)
        {
            bool pacienteExiste = modeloPaciente.Exists(c => c.idPaciente == idCita.IdPaciente);
        }




    }
}

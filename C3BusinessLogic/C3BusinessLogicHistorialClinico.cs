using AppWebSistemaClinica.C1Model;
using AppWebSistemaClinica.C2DataAccess.C2AccessGeneric;

namespace AppWebSistemaClinica.C3BusinessLogic
{
    internal class C3BusinessLogicHistorialClinico
    {

        readonly C2AccessGenericIGeneric<C1ModelPaciente> modeloPaciente = new C2AccessGenericGeneric<C1ModelPaciente>();
        readonly C2AccessGenericIGeneric<C1ModelHistorialClinico> modeloHistorialClinico = new C2AccessGenericGeneric<C1ModelHistorialClinico>();

        public void insertarHistorialClinico(C1ModelHistorialClinico IdHistorialClinico)
        {
            bool registroMedicoExiste = modeloPaciente.Exists(c => c.idPaciente == IdHistorialClinico.IdPaciente);

            if (!registroMedicoExiste)
            {
                throw new ArgumentException("El registro medico con el ID especificado no existe. ");
            }

            try
            {
                modeloHistorialClinico.Add(IdHistorialClinico);
                modeloHistorialClinico.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar la cita");
            }
        }

        public void actualizarHistorialClinico(C1ModelHistorialClinico IdHistorialClinico)
        {
            var historialClinicoExiste = modeloHistorialClinico.GetById(IdHistorialClinico.Id_HistorialClinico);
            bool registroMedicoExiste = modeloPaciente.Exists(c => c.idPaciente == IdHistorialClinico.IdPaciente);

            if (!registroMedicoExiste)
            {
                throw new ArgumentException("El registro medico con el ID especificado no existe. ");
            }

            if (historialClinicoExiste == null)
            {
                throw new ArgumentException("El historial clinico con el ID especificado no existe. ");
            }

            try
            {
                historialClinicoExiste.Id_HistorialClinico = IdHistorialClinico.Id_HistorialClinico;
                historialClinicoExiste.DescripcionHisClinico = IdHistorialClinico.DescripcionHisClinico;
                historialClinicoExiste.NotasMedicasHisClinico = IdHistorialClinico.NotasMedicasHisClinico;
                historialClinicoExiste.ListEnfermedadesRecientHisClinico = IdHistorialClinico.ListEnfermedadesRecientHisClinico;
                historialClinicoExiste.IdPaciente = IdHistorialClinico.IdPaciente;

                modeloHistorialClinico.Update(historialClinicoExiste);
                modeloHistorialClinico.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el historial clinico. " + ex.Message, ex);
            }

        }

        public void eliminarHistorialClinico(int IdHistorialClinico)
        {
            try
            {
                var historialClinicoExiste = modeloHistorialClinico.GetById(IdHistorialClinico);

                if (historialClinicoExiste == null)
                {
                    throw new Exception("Error: El historial clinico con el ID especificado no existe");
                }

                modeloHistorialClinico.HardDelete(historialClinicoExiste);
                modeloHistorialClinico.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el historial clinico. " + ex.Message, ex);
            }
        }

        public C1ModelHistorialClinico buscarHistorialClinicoPorId(int IdHistorialClinico)
        {
            try
            {
                var historialClinicoExiste = modeloHistorialClinico.GetById(IdHistorialClinico);

                if (historialClinicoExiste == null)
                {
                    throw new Exception("Error: El historial clinico con el ID especificado no existe");
                }

                return historialClinicoExiste;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el historial clinico. " + ex.Message, ex);
            }
        }

        public List<C1ModelHistorialClinico> imprimirHistorialClinico()
        {
            try
            {
                IQueryable<C1ModelHistorialClinico> list = modeloHistorialClinico.GetAll();
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las citas. " + ex.Message, ex);
            }
        }

    }
}

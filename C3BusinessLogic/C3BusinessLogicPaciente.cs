using AppWebSistemaClinica.C1Model;
using AppWebSistemaClinica.C2DataAccess.C2AccessGeneric;

namespace AppWebSistemaClinica.C3BusinessLogic
{
    public class C3BusinessLogicPaciente
    {
        readonly C2AccessGenericIGeneric<C1ModelPaciente> modeloPaciente = new C2AccessGenericGeneric<C1ModelPaciente>();

        public void insertarPaciente(C1ModelPaciente IdPaciente)
        {
            try
            {
                modeloPaciente.Add(IdPaciente);
                modeloPaciente.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el paciente");
            }

        }

        public void actualizarPaciente(C1ModelPaciente IdPaciente)
        {
            var pacienteExiste = modeloPaciente.GetById(IdPaciente.idPaciente);
            
            if (pacienteExiste == null)
            {
                // Si el usuario no existe, lanza una excepcion con mensaje personalizado
                throw new ArgumentException("El paciente con el ID especificado no existe. ");
            }

            try
            {
                pacienteExiste.CedulaPaciente = IdPaciente.CedulaPaciente;
                pacienteExiste.EdadPaciente = IdPaciente.EdadPaciente;
                pacienteExiste.TelefonoPaciente = IdPaciente.TelefonoPaciente;
                pacienteExiste.NombrePaciente = IdPaciente.NombrePaciente;
                pacienteExiste.ApellidoPaciente = IdPaciente.ApellidoPaciente;
                pacienteExiste.CorreoPaciente = IdPaciente.CorreoPaciente;
                pacienteExiste.FechaNacimientoPaciente = IdPaciente.FechaNacimientoPaciente;
                pacienteExiste.EstadoCivilPaciente = IdPaciente.EstadoCivilPaciente;

                modeloPaciente.Update(pacienteExiste);
                modeloPaciente.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el paciente: " + ex.Message, ex);
            }
        }

        public void eliminarPaciente(int IdPaciente)
        {
            try
            {
                var pacienteExiste = modeloPaciente.GetById(IdPaciente);

                if (pacienteExiste == null)
                {
                    throw new Exception("Error: El paciente con el ID especificado no existe");
                }

                modeloPaciente.HardDelete(pacienteExiste);
                modeloPaciente.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el paciente. " + ex.Message, ex);
            }
        }

        public C1ModelPaciente buscarPacientePorId(int IdPaciente)
        {
            try
            {
                var pacienteExiste = modeloPaciente.GetById(IdPaciente);

                if (pacienteExiste == null)
                {
                    throw new Exception("Error: El paciente con el ID especificado no existe");
                }

                return pacienteExiste;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el paciente. " + ex.Message, ex);
            }
        }

        public List<C1ModelPaciente> imprimirPaciente()
        {
            try
            {
                IQueryable<C1ModelPaciente> list = modeloPaciente.GetAll();
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los pacientes. " + ex.Message, ex);
            }
        }

    }
}

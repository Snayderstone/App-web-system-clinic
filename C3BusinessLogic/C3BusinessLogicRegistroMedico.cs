using AppWebSistemaClinica.C1Model;
using AppWebSistemaClinica.C2DataAccess.C2AccessGeneric;

namespace AppWebSistemaClinica.C3BusinessLogic
{
    internal class C3BusinessLogicRegistroMedico
    {
        readonly C2AccessGenericIGeneric<C1ModelRegistroMedico> modeloRegistroMedico = new C2AccessGenericGeneric<C1ModelRegistroMedico>();

        public void insertarResgistroMedico(C1ModelRegistroMedico IdResgistroMedico)
        {
            
            try
            {
                // El perfil existe, procede a realizar la insercion
                modeloRegistroMedico.Add(IdResgistroMedico);
                modeloRegistroMedico.SaveChanges();
            }
            catch (Exception ex)
            {
                // Se lanza una excepcion en caso de ocuriri algun error en la insercion
                throw new Exception("Error al insertar el perfil");
            }
        }  

        public void actualizarPerfil(C1ModelRegistroMedico IdRegistroMedico)
        {
            var registromedicoExiste = modeloRegistroMedico.GetById(IdRegistroMedico.IdRegistroMedico);

            if (registromedicoExiste == null)
            {
                // Si el usuario no existe, lanza una excepcion con mensaje personalizado
                throw new ArgumentException("El registro medico con el ID especificado no existe. ");
            }

            try
            {
                // Actualiza los campos de perfil
                registromedicoExiste.DetallesRegistroMedico = IdRegistroMedico.DetallesRegistroMedico;
                registromedicoExiste.HistoriaCliente = IdRegistroMedico.HistoriaCliente;
                
                modeloRegistroMedico.Update(registromedicoExiste);
                modeloRegistroMedico.SaveChanges();
            }
            catch (Exception ex)
            {
                // Lanzar la excepción hacia la capa de presentación
                throw new Exception("Error al actualizar el registro medico: " + ex.Message, ex);
            }
        }

        public void eliminarRegistroMedico(int IdRegistroMedico)
        {
            try
            {
                var registromedicoExiste = modeloRegistroMedico.GetById(IdRegistroMedico);

                if (registromedicoExiste == null)
                {
                    throw new Exception("Error: El registro medico con el ID especificado no existe");
                }

                modeloRegistroMedico.HardDelete(registromedicoExiste);
                modeloRegistroMedico.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el registro medico. " + ex.Message, ex);
            }
        }

        public C1ModelRegistroMedico buscarRegistroMedicoPorId(int IdRegistroMedico)
        {
            try
            {
                var registromedicoExiste = modeloRegistroMedico.GetById(IdRegistroMedico);

                if (registromedicoExiste == null)
                {
                    throw new Exception("Error: El registro medico con el ID especificado no existe");
                }

                return registromedicoExiste;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el registro medico. " + ex.Message, ex);
            }
        }

        public List<C1ModelRegistroMedico> imprimirRegistroMedico()
        {
            try
            {
                IQueryable<C1ModelRegistroMedico> list = modeloRegistroMedico.GetAll();
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los registros medicos. " + ex.Message, ex);
            }
        }

    }
}

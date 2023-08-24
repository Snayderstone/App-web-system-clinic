using AppWebSistemaClinica.C1Model;
using AppWebSistemaClinica.C2DataAccess.C2AccessGeneric;

namespace AppWebSistemaClinica.C3BusinessLogic
{
    internal class C3BusinessLogicMedico
    {
        readonly C2AccessGenericIGeneric<C1ModelCita> modeloCita = new C2AccessGenericGeneric<C1ModelCita>();
        readonly C2AccessGenericIGeneric<C1ModelEspecialidad> modeloEspecialidad = new C2AccessGenericGeneric<C1ModelEspecialidad>();
        readonly C2AccessGenericIGeneric<C1ModelMedico> modeloMedico = new C2AccessGenericGeneric<C1ModelMedico>();

        public void insertarMedico(C1ModelMedico IdMedico)
        {
            
            bool especialidadExiste = modeloEspecialidad.Exists(c => c.IdEspecialidad == IdMedico.IdEspecialidad);

            if (!especialidadExiste)
            {
                throw new ArgumentException("La especialidad con el ID especificado no existe. ");
            }

            try
            {
                modeloMedico.Add(IdMedico);
                modeloMedico.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el medico");
            }
        }

        public void actualizarMedico(C1ModelMedico IdMedico)
        {
            var medicoExiste = modeloMedico.GetById(IdMedico.IdMedico);
            bool especialidadExiste = modeloEspecialidad.Exists(c => c.IdEspecialidad == IdMedico.IdEspecialidad);

            if (!especialidadExiste)
            {
                throw new ArgumentException("La especialidad con el ID especificado no existe. ");
            }

            if (medicoExiste == null)
            {
                throw new ArgumentException("El medico con el ID especificado no existe. ");
            }

            try
            {
                medicoExiste.IdMedico = IdMedico.IdMedico;
                medicoExiste.NombreMedico = IdMedico.NombreMedico;
                medicoExiste.ApellidoMedico = IdMedico.ApellidoMedico;
                medicoExiste.TelefonoMedico = IdMedico.TelefonoMedico;
                medicoExiste.CorreoMedico = IdMedico.CorreoMedico;
                medicoExiste.HorarioMedico = IdMedico.HorarioMedico;
                medicoExiste.IdEspecialidad = IdMedico.IdEspecialidad;

                modeloMedico.Update(medicoExiste);
                modeloMedico.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el medico " + ex.Message, ex);
            }

        }

        public void eliminarMedico(int IdMedico)
        {
            try
            {
                var medicoExiste = modeloMedico.GetById(IdMedico);

                if (medicoExiste == null)
                {
                    throw new Exception("Error: El medico con el ID especificado no existe");
                }

                modeloMedico.HardDelete(medicoExiste);
                modeloMedico.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el medico. " + ex.Message, ex);
            }
        }

        public C1ModelMedico buscarMedicoPorId(int IdMedico)
        {
            try
            {
                var medicoExiste = modeloMedico.GetById(IdMedico);

                if (medicoExiste == null)
                {
                    throw new Exception("Error: El medico con el ID especificado no existe");
                }

                return medicoExiste;    
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el medico. " + ex.Message, ex);
            }
        }

        public List<C1ModelMedico> imprimirMedicos()
        {
            try
            {
                IQueryable<C1ModelMedico> list = modeloMedico.GetAll();
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los medicos. " + ex.Message, ex);
            }
        }

    }
}

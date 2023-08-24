using AppWebSistemaClinica.C1Model;
using AppWebSistemaClinica.C2DataAccess.C2AccessGeneric;

namespace AppWebSistemaClinica.C3BusinessLogic
{
    internal class C3BusinessLogicCita
    {
        readonly C2AccessGenericIGeneric<C1ModelCita> modeloCita = new C2AccessGenericGeneric<C1ModelCita>();
        readonly C2AccessGenericIGeneric<C1ModelMedico> modeloMedico = new C2AccessGenericGeneric<C1ModelMedico>();

        public void insertarCita(C1ModelCita IdCita)
        {
            bool medicoExiste = modeloMedico.Exists(C => C.IdMedico == IdCita.IdMedico);

            if (!medicoExiste)
            {
                throw new ArgumentException("El medico con el ID especificado no existe. ");
            }

            try
            {
                modeloCita.Add(IdCita);
                modeloCita.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar la cita");
            }
        }

        public void actualizarCita(C1ModelCita IdCita)
        {
            var citaExiste = modeloCita.GetById(IdCita.IdCita);
            bool medicoExiste = modeloMedico.Exists(C => C.IdMedico == IdCita.IdMedico);

            if (!medicoExiste)
            {
                throw new ArgumentException("El medico con el ID especificado no existe. ");
            }

            if (citaExiste == null)
            {
                throw new ArgumentException("La cita con el ID especificado no existe. ");
            }

            try
            {
                citaExiste.FechaCita = IdCita.FechaCita;
                citaExiste.HoraInicioCita = IdCita.HoraInicioCita;
                citaExiste.HoraFinCita = IdCita.HoraFinCita;
                citaExiste.EstadoCita = IdCita.EstadoCita;
                citaExiste.IdMedico = IdCita.IdMedico;

                modeloCita.Update(citaExiste);
                modeloCita.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la cita. " + ex.Message, ex);
            }
        }

        public void eliminarCita(int IdCita)
        {
            try
            {
                var citalExiste = modeloCita.GetById(IdCita);

                if (citalExiste == null)
                {
                    throw new Exception("Error: La cita con el ID especificado no existe");
                }

                modeloCita.HardDelete(citalExiste);
                modeloCita.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la cita. " + ex.Message, ex);
            }
        }

        public C1ModelCita buscarCitaPorId(int IdCita)
        {
            try
            {
                var citalExiste = modeloCita.GetById(IdCita);

                if (citalExiste == null)
                {
                    throw new Exception("Error: La cita con el ID especificado no existe");
                }

                return citalExiste;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar la cita. " + ex.Message, ex);
            }
        }

        public List<C1ModelCita> imprimirCitas()
        {
            try
            {
                IQueryable<C1ModelCita> list = modeloCita.GetAll();
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las citas. " + ex.Message, ex);
            }
        }
    }
}

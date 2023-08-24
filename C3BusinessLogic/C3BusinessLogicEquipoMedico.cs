using AppWebSistemaClinica.C1Model;
using AppWebSistemaClinica.C2DataAccess.C2AccessGeneric;

namespace AppWebSistemaClinica.C3BusinessLogic
{
    public class C3BusinessLogicEquipoMedico
    {
        readonly C2AccessGenericIGeneric<C1ModelEquipoMedicoClinica> modeloEquipoMedicoClinica = new C2AccessGenericGeneric<C1ModelEquipoMedicoClinica>();
        readonly C2AccessGenericIGeneric<C1ModelEquipoMedico> modeloEquipoMedico = new C2AccessGenericGeneric<C1ModelEquipoMedico>();

        public void insertarEquipoMedico(C1ModelEquipoMedico IdEquipoMedico)
        {
            bool equipoMedicoClinicaExiste = modeloEquipoMedicoClinica.Exists(C => C.IdEquipoMedico == IdEquipoMedico.IdEquipoMedico);
            
            if (!equipoMedicoClinicaExiste)
            {
                throw new ArgumentException("El equipo medico con el ID especificado no existe. ");
            }

            try
            {
                modeloEquipoMedico.Add(IdEquipoMedico);
                modeloEquipoMedico.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el equipo medico");
            }

        }

        public void acturalizarEquipoMedico(C1ModelEquipoMedico IdEquipoMedico)
        {
            var equipoMedicoExiste = modeloEquipoMedico.GetById(IdEquipoMedico.IdEquipoMedico);
            bool equipoMedicoClinicaExiste = modeloEquipoMedicoClinica.Exists(C => C.IdEquipoMedico == IdEquipoMedico.IdEquipoMedico);

            if (!equipoMedicoClinicaExiste)
            {
                throw new ArgumentException("El equipo medico con el ID especificado no existe. ");
            }

            if (equipoMedicoExiste == null)
            {
                throw new ArgumentException("El equipo medico con el ID especificado no existe. ");
            }

            try
            {
                equipoMedicoExiste.IdEquipoMedico = IdEquipoMedico.IdEquipoMedico;
                equipoMedicoExiste.NombreEquipoMedico = IdEquipoMedico.NombreEquipoMedico;
                equipoMedicoExiste.DescripcionEquipoMedico = IdEquipoMedico.DescripcionEquipoMedico;

                modeloEquipoMedico.Update(equipoMedicoExiste);
                modeloEquipoMedico.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el equipo medico. " + ex.Message, ex);
            }

        }

        public void eliminarEquipoMedico(int IdEquipoMedico)
        {
            try
            {
                var equipoMedicoExiste = modeloEquipoMedico.GetById(IdEquipoMedico);

                if (equipoMedicoExiste == null)
                {
                    throw new Exception("Error: La cita con el ID especificado no existe");
                }

                modeloEquipoMedico.HardDelete(equipoMedicoExiste);
                modeloEquipoMedico.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el equipo medico. " + ex.Message, ex);
            }
        }

        public C1ModelEquipoMedico buscarEquipoMedicoPorId(int IdEquipoMedico)
        {
            try
            {
                var equipoMedicoExiste = modeloEquipoMedico.GetById(IdEquipoMedico);

                if (equipoMedicoExiste == null)
                {
                    throw new Exception("Error: La cita con el ID especificado no existe");
                }

                return equipoMedicoExiste;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el equipo medico. " + ex.Message, ex);
            }
        }

        public List<C1ModelEquipoMedico> imprimirEquipoMedico()
        {
            try
            {
                IQueryable<C1ModelEquipoMedico> list = modeloEquipoMedico.GetAll();
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los equipos medicos. " + ex.Message, ex);
            }
        }

    }
}

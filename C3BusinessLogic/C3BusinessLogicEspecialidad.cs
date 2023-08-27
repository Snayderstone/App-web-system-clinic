using AppWebSistemaClinica.C1Model;
using AppWebSistemaClinica.C2DataAccess.C2AccessGeneric;

namespace AppWebSistemaClinica.C3BusinessLogic
{
    public class C3BusinessLogicEspecialidad
    {
        
        readonly C2AccessGenericIGeneric<C1ModelEspecialidad> modeloEspecialidad = new C2AccessGenericGeneric<C1ModelEspecialidad>();

        public void insertarEspecialidad(C1ModelEspecialidad IdEspecialidad)
        {
            try
            {
                modeloEspecialidad.Add(IdEspecialidad);
                modeloEspecialidad.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar la especialidad");
            }
        }

        public void actualizarEspecialidad(C1ModelEspecialidad IdEspecialidad)
        {
            var especialidadExiste = modeloEspecialidad.GetById(IdEspecialidad.IdEspecialidad);

            if (especialidadExiste == null)
            {
                throw new ArgumentException("La especialidad con el ID especificado no existe. ");
            }

            try
            {
                especialidadExiste.IdEspecialidad = IdEspecialidad.IdEspecialidad;
                especialidadExiste.DescripcionEspecialidad = IdEspecialidad.DescripcionEspecialidad;
                especialidadExiste.PrecioEspecialidad = IdEspecialidad.PrecioEspecialidad;

                modeloEspecialidad.Update(especialidadExiste);
                modeloEspecialidad.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la especialidad. " + ex.Message, ex);
            }

        }

        public void eliminarEspecialidad(int IdEspecialidad)
        {
            try
            {
                var especialidadExiste = modeloEspecialidad.GetById(IdEspecialidad);

                if (especialidadExiste == null)
                {
                    throw new Exception("Error: La especialidad con el ID especificado no existe");
                }

                modeloEspecialidad.HardDelete(especialidadExiste);
                modeloEspecialidad.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la especialidad. " + ex.Message, ex);
            }
        }

        public C1ModelEspecialidad buscarEspecialidadPorId(int IdEspecialidad)
        {
            try
            {
                var especialidadExiste = modeloEspecialidad.GetById(IdEspecialidad);

                if (especialidadExiste == null)
                {
                    throw new Exception("Error: La especialidad con el ID especificado no existe");
                }

                return especialidadExiste;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la especialidad. " + ex.Message, ex);
            }
        }

        public List<C1ModelEspecialidad> imprimirEspecialidad()
        {
            try
            {
                IQueryable<C1ModelEspecialidad> list = modeloEspecialidad.GetAll();
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las especialidades. " + ex.Message, ex);
            }
        }

    }
}

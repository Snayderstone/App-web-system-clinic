using AppWebSistemaClinica.C1Model;
using AppWebSistemaClinica.C2DataAccess.C2AccessGeneric;

namespace AppWebSistemaClinica.C3BusinessLogic
{
    public class C3BusinessLogicClinica
	{
		readonly C2AccessGenericIGeneric<C1ModelEquipoMedicoClinica> modeloEquipoMedicoClinica = new C2AccessGenericGeneric<C1ModelEquipoMedicoClinica>();
		readonly C2AccessGenericIGeneric<C1ModelCita> modeloCita = new C2AccessGenericGeneric<C1ModelCita>();
		readonly C2AccessGenericIGeneric<C1ModelClinica> modeloClinica = new C2AccessGenericGeneric<C1ModelClinica>();

		public void insertarClinica(C1ModelClinica IdClinica)
		{
            try
            {
                // El perfil existe, procede a realizar la insercion
                modeloClinica.Add(IdClinica);
                modeloClinica.SaveChanges();
            }
            catch (Exception ex)
            {
                // Se lanza una excepcion en caso de ocuriri algun error en la insercion
                throw new Exception("Error al insertar la clinica");
            }
        }

        public void actualizarClinica(C1ModelClinica IdClinica)
        {
            var clinicaExiste = modeloClinica.GetById(IdClinica.IdClinica);

            if (clinicaExiste == null)
            {
                // Si el usuario no existe, lanza una excepcion con mensaje personalizado
                throw new ArgumentException("La clinica con el ID especificado no existe. ");
            }

            try
            {
                // Actualiza los campos de perfil
                clinicaExiste.IdClinica = IdClinica.IdClinica;
                clinicaExiste.NombreClinica = IdClinica.NombreClinica;
                clinicaExiste.CapacidadClinica = IdClinica.CapacidadClinica;    
                clinicaExiste.UbicacionClinica = IdClinica.UbicacionClinica;    
                clinicaExiste.PrecioConsultaClinica = IdClinica.PrecioConsultaClinica;

                modeloClinica.Update(clinicaExiste);
                modeloClinica.SaveChanges();
            }
            catch (Exception ex)
            {
                // Lanzar la excepción hacia la capa de presentación
                throw new Exception("Error al actualizar la clinica: " + ex.Message, ex);
            }

        }

        public void eliminarClinica(int IdClinica)
        {
            try
            {
                var clinicaExiste = modeloClinica.GetById(IdClinica);

                if (clinicaExiste == null)
                {
                    throw new Exception("Error: La clinica con el ID especificado no existe");
                }

                modeloClinica.HardDelete(clinicaExiste);
                modeloClinica.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la clinica. " + ex.Message, ex);
            }
        }

        public C1ModelClinica buscarClinicaPorId(int IdClinica)
        {
            try
            {
                var clinicaExiste = modeloClinica.GetById(IdClinica);

                if (clinicaExiste == null)
                {
                    throw new Exception("Error: La clinica con el ID especificado no existe");
                }

                return clinicaExiste;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la clinica. " + ex.Message, ex);
            }
        }

        public List<C1ModelClinica> imprimirClinica()
        {
            try
            {
                IQueryable<C1ModelClinica> list = modeloClinica.GetAll();
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las clinicas. " + ex.Message, ex);
            }
        }

	}
}

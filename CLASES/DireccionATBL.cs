using AppWebSistemaClinica.C1Model;
using AppWebSistemaClinica.C2DataAccess.C2AccessGeneric;

namespace AppWebSistemaClinica.C3BusinessLogic
{
    public class DireccionATBL
    {
        readonly C2AccessGenericIGeneric<TipoDireccionAT> modeloTipoDireccion = new C2AccessGenericGeneric<TipoDireccionAT>();
        readonly C2AccessGenericIGeneric<DireccionAT> modeloDireccion = new C2AccessGenericGeneric<DireccionAT>();

        public void insertarDireccion(DireccionAT IdDireccion)
        {
            bool tipodireccionExiste = modeloTipoDireccion.Exists(c => c.Id_TipoDireccion == IdDireccion.Id_TipoDireccion);

            if (!tipodireccionExiste)
            {
                throw new ArgumentException("El tipo de direccion con el ID especificado no existe. ");
            }

            try
            {
                modeloDireccion.Add(IdDireccion);
                modeloDireccion.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el tipo de direccion");
            }
        }

        public void actualizarDireccion(DireccionAT IdDireccion)
        {
            var direccionExiste = modeloDireccion.GetById(IdDireccion.Id_Direccion);
            bool tipodireccionExiste = modeloTipoDireccion.Exists(c => c.Id_TipoDireccion == IdDireccion.Id_TipoDireccion);

            if (!tipodireccionExiste)
            {
                throw new ArgumentException("El tipo de direccion con el ID especificado no existe. ");
            }

            if (direccionExiste == null)
            {
                throw new ArgumentException("La direccion con el ID especificado no existe. ");
            }

            try
            {
                direccionExiste.Id_Direccion = IdDireccion.Id_Direccion;
                direccionExiste.Id_TipoDireccion = IdDireccion.Id_TipoDireccion;
                direccionExiste.idPaciente = IdDireccion.idPaciente;
                direccionExiste.Calle_Principal = IdDireccion.Calle_Principal;
                direccionExiste.Calle_Secundaria = IdDireccion.Calle_Secundaria;
                direccionExiste.Num_Casa = IdDireccion.Num_Casa;
                direccionExiste.Referencia = IdDireccion.Referencia;
                direccionExiste.Estado = IdDireccion.Estado;
                direccionExiste.TipoDireccionAT = IdDireccion.TipoDireccionAT;

                modeloDireccion.Update(direccionExiste);
                modeloDireccion.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la direccion. " + ex.Message, ex);
            }
        }

        public void eliminarDireccion(int IdDireccion)
        {
            try
            {
                var direccionExiste = modeloDireccion.GetById(IdDireccion);

                if (direccionExiste == null)
                {
                    throw new Exception("Error: La cita con el ID especificado no existe");
                }

                modeloDireccion.HardDelete(direccionExiste);
                modeloDireccion.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la direecion. " + ex.Message, ex);
            }
        }

        public DireccionAT buscarDireccionPorId(int IdDireccion)
        {
            try
            {
                var direccionExiste = modeloDireccion.GetById(IdDireccion);

                if (direccionExiste == null)
                {
                    throw new Exception("Error: La cita con el ID especificado no existe");
                }

                return direccionExiste;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la direecion. " + ex.Message, ex);
            }
        }

        public List<DireccionAT> imprimirDireccion()
        {
            try
            {
                IQueryable<DireccionAT> list = modeloDireccion.GetAll();
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las citas. " + ex.Message, ex);
            }
        }

    }
}

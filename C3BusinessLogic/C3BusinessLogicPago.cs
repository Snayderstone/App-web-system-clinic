using AppWebSistemaClinica.C1Model;
using AppWebSistemaClinica.C2DataAccess.C2AccessGeneric;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AppWebSistemaClinica.C3BusinessLogic
{
    public class C3BusinessLogicPago
    {
        readonly C2AccessGenericIGeneric<C1ModelPago> modeloPago = new C2AccessGenericGeneric<C1ModelPago>();

        public void insertarPago(C1ModelPago IdPago)
        {
            try
            {
                // La funcion existe, procede a realizar la insercion
                modeloPago.Add(IdPago);
                modeloPago.SaveChanges();
            }
            catch (Exception ex)
            {
                // Se lanza una excepcion en caso de ocurira algun error en la insercion
                throw new Exception("Error al insertar el pago");
            }
        }

        public void actualizarPago(C1ModelPago IdPago)
        {
            var pagoExiste = modeloPago.GetById(IdPago.IdPago);

            if (pagoExiste == null)
            {
                // Si el usuario no existe, lanza una excepcion con mensaje personalizado
                throw new ArgumentException("El pago con el ID especificado no existe. ");
            }

            try
            {
                // Actualiza los campos de funcion
                pagoExiste.FormaPago = IdPago.FormaPago;
                pagoExiste.DescripcionPago = IdPago.DescripcionPago;  

                modeloPago.Update(pagoExiste);
                modeloPago.SaveChanges();
            }
            catch (Exception ex)
            {
                // Lanzar la excepción hacia la capa de presentación
                throw new Exception("Error al actualizar el pago: " + ex.Message, ex);
            }
        }

        public void eliminarPago(int IdPago)
        {
            try
            {
                var pagoExiste = modeloPago.GetById(IdPago);

                if (pagoExiste == null)
                {
                    throw new Exception("Error: El pago con el ID especificado no existe");
                }

                modeloPago.HardDelete(pagoExiste);
                modeloPago.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el pago. " + ex.Message, ex);
            }
        }

        public C1ModelPago buscarPagoPorId(int IdPago)
        {
            try
            {
                var pagoExiste = modeloPago.GetById(IdPago);

                if (pagoExiste == null)
                {
                    throw new Exception("Error: El pago con el ID especificado no existe");
                }

                return pagoExiste;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el pago. " + ex.Message, ex);
            }
        }

        public List<C1ModelPago> imprimirPago()
        {
            try
            {
                IQueryable<C1ModelPago> list = modeloPago.GetAll();
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los pagos. " + ex.Message, ex);
            }
        }

    }
}

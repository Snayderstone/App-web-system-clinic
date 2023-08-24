using AppWebSistemaClinica.C1Model;
using AppWebSistemaClinica.C2DataAccess.C2AccessGeneric;

namespace AppWebSistemaClinica.C3BusinessLogic
{
    internal class C3BusinessLogicDetalleFactura
    {
    
        readonly C2AccessGenericIGeneric<C1ModelPago> modeloPago = new C2AccessGenericGeneric<C1ModelPago>();
        readonly C2AccessGenericIGeneric<C1ModelDetalleFactura> modeloDetalleFactura = new C2AccessGenericGeneric<C1ModelDetalleFactura>();

        public void insertarDetalleFactura(C1ModelDetalleFactura IdDetalleFactura)
        {
            bool pagoExiste = modeloPago.Exists(c => c.IdPago == IdDetalleFactura.IdPago);

            if (!pagoExiste)
            {
                throw new ArgumentException("El pago con el ID especificado no existe. ");
            }

            try
            {
                modeloDetalleFactura.Add(IdDetalleFactura);
                modeloDetalleFactura.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el detalle de factura");
            }

        }

        public void actualizarDetalleFactura(C1ModelDetalleFactura IdDetalleFactura)
        {
            var detalleFacturaExiste = modeloDetalleFactura.GetById(IdDetalleFactura.IdDetalleFactura);
            bool pagoExiste = modeloPago.Exists(c => c.IdPago == IdDetalleFactura.IdPago);

            if (!pagoExiste)
            {
                throw new ArgumentException("El pago con el ID especificado no existe. ");
            }

            if (detalleFacturaExiste == null)
            {
                throw new ArgumentException("El detalle de factura con el ID especificado no existe. ");
            }

            try
            {
                detalleFacturaExiste.IdDetalleFactura = IdDetalleFactura.IdDetalleFactura;
                detalleFacturaExiste.DescripcionDetalleFactura = IdDetalleFactura.DescripcionDetalleFactura;
                detalleFacturaExiste.CantidadCitasDetalleFactura = IdDetalleFactura.CantidadCitasDetalleFactura;
                detalleFacturaExiste.PrecioUnitarioDetalleFactura = IdDetalleFactura.PrecioUnitarioDetalleFactura;
                detalleFacturaExiste.PrecioTotalDetalleFactura = IdDetalleFactura.PrecioTotalDetalleFactura;
                detalleFacturaExiste.IdPago = IdDetalleFactura.IdPago;


                modeloDetalleFactura.Update(detalleFacturaExiste);
                modeloDetalleFactura.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el detalle de factura. " + ex.Message, ex);
            }
        }

        public void eliminarDetalleFactura(int IdDetalleFactura)
        {
            try
            {
                var detalleFacturaExiste = modeloDetalleFactura.GetById(IdDetalleFactura);

                if (detalleFacturaExiste == null)
                {
                    throw new Exception("Error: El detalle de factura con el ID especificado no existe");
                }

                modeloDetalleFactura.HardDelete(detalleFacturaExiste);
                modeloDetalleFactura.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la cita. " + ex.Message, ex);
            }
        }

        public C1ModelDetalleFactura buscarDetalleFacturaPorId(int IdDetalleFactura)
        {
            try
            {
                var detalleFacturaExiste = modeloDetalleFactura.GetById(IdDetalleFactura);

                if (detalleFacturaExiste == null)
                {
                    throw new Exception("Error: El detalle de factura con el ID especificado no existe");
                }

                return detalleFacturaExiste;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la cita. " + ex.Message, ex);
            }
        } 

        public List<C1ModelDetalleFactura> imprimirDetalleFactura()
        {
            try
            {
                IQueryable<C1ModelDetalleFactura> list = modeloDetalleFactura.GetAll();
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el detalle factura. " + ex.Message, ex);
            }
        }

    }
}

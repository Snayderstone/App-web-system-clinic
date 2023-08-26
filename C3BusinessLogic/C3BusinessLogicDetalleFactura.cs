using AppWebSistemaClinica.C1Model;
using AppWebSistemaClinica.C2DataAccess.C2AccessGeneric;

namespace AppWebSistemaClinica.C3BusinessLogic
{
    internal class C3BusinessLogicDetalleFactura
    {
    
        readonly C2AccessGenericIGeneric<C1ModelDetalleFactura> modeloDetalleFactura = new C2AccessGenericGeneric<C1ModelDetalleFactura>();

        public void insertarDetalleFactura(C1ModelDetalleFactura IdDetalleFactura)
        {

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

            if (detalleFacturaExiste == null)
            {
                throw new ArgumentException("El detalle de factura con el ID especificado no existe. ");
            }

            try
            {
                detalleFacturaExiste.IdDetalleFactura = IdDetalleFactura.IdDetalleFactura;
                detalleFacturaExiste.DescripcionDetalleFactura = IdDetalleFactura.DescripcionDetalleFactura;
                detalleFacturaExiste.PrecioUnitarioDetalleFactura = IdDetalleFactura.PrecioUnitarioDetalleFactura;
                detalleFacturaExiste.IvaDetalleFactura = IdDetalleFactura.IvaDetalleFactura;
                detalleFacturaExiste.OtroImpuesto = IdDetalleFactura.OtroImpuesto;
                detalleFacturaExiste.PrecioTotalDetalleFactura = IdDetalleFactura.PrecioTotalDetalleFactura;


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

using AppWebSistemaClinica.C1Model;
using AppWebSistemaClinica.C2DataAccess.C2AccessGeneric;

namespace AppWebSistemaClinica.C3BusinessLogic
{
    internal class C3BusinessLogicFactura
    {
      
        readonly C2AccessGenericIGeneric<C1ModelFactura> modeloFactura = new C2AccessGenericGeneric<C1ModelFactura>();

        public void insertarFactura(C1ModelFactura IdFactura)
        {
            try
            {
                modeloFactura.Add(IdFactura);
                modeloFactura.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar la factura");
            }
        }

        public void actualizarFactura(C1ModelFactura IdFactura)
        {
            var facturaExiste = modeloFactura.GetById(IdFactura.IdFactura);

            if (facturaExiste == null)
            {
                throw new ArgumentException("La factura con el ID especificado no existe. ");
            }

            try
            {
                facturaExiste.IdFactura = IdFactura.IdFactura;
                facturaExiste.MontoTotalFctura = IdFactura.MontoTotalFctura;
                facturaExiste.EstadoPagoFactura = IdFactura.EstadoPagoFactura;
                facturaExiste.FechaFactura = IdFactura.FechaFactura;

                modeloFactura.Update(facturaExiste);
                modeloFactura.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la factura. " + ex.Message, ex);
            }
        }

        public void eliminarFactura(int IdFactura)
        {
            try
            {
                var facturaExiste = modeloFactura.GetById(IdFactura);

                if (facturaExiste == null)
                {
                    throw new Exception("Error: La factura con el ID especificado no existe");
                }

                modeloFactura.HardDelete(facturaExiste);
                modeloFactura.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la factura. " + ex.Message, ex);
            }
        }

        public C1ModelFactura buscarFacturaPorId(int IdFactura)
        {
            try
            {
                var facturaExiste = modeloFactura.GetById(IdFactura);

                if (facturaExiste == null)
                {
                    throw new Exception("Error: La factura con el ID especificado no existe");
                }

                return facturaExiste;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la factura. " + ex.Message, ex);
            }
        }

        public List<C1ModelFactura> imprimirFacturas()
        {
            try
            {
                IQueryable<C1ModelFactura> list = modeloFactura.GetAll();
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las facturas. " + ex.Message, ex);
            }
        }

    }
}

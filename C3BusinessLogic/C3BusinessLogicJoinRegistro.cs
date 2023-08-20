using AppWebSistemaClinica.C1Model;
using AppWebSistemaClinica.C2DataAccess.C2AccessGeneric;

namespace AppWebSistemaClinica.C3BusinessLogic
{
    public class C3BusinessLogicJoinRegistro
    {
        readonly C2AccessGenericGeneric<C1ModelFuncion> modeloFuncion = new C2AccessGenericGeneric<C1ModelFuncion>();
        readonly C2AccessGenericGeneric<C1ModelRol> modeloRol = new C2AccessGenericGeneric<C1ModelRol>();
        readonly C2AccessGenericGeneric<C1ModelUsuario> modeloUsuario = new C2AccessGenericGeneric<C1ModelUsuario>();


            //public List<C1ModelVenta> registroUsuarioPerfilRolFuncion()
            //{
            //    try
            //    {
            //        IQueryable<C1ModelVenta> listaVentas = modeloventa.GetAll()
            //     .Include(venta => venta.C1ModelFactura)
            //         .ThenInclude(factura => factura.C1ModelCliente)
            //     .Include(venta => venta.C1ModelProducto)
            //         .ThenInclude(producto => producto.C1ModelCategoria)
            //     .Include(venta => venta.C1ModelProducto)
            //         .ThenInclude(producto => producto.C1ModelProveedor);

            //        return listaVentas.ToList();
            //    }
            //    catch (Exception ex)
            //    {
            //        throw new Exception("Error al obtener todas las ventas: " + ex.Message, ex);
            //    }
            //}
        




    }
}

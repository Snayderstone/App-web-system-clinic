//using AppWebSistemaClinica.C1Model;
//using AppWebSistemaClinica.C2DataAccess.C2AccessGeneric;
//using Microsoft.EntityFrameworkCore;

//namespace AppWebSistemaClinica.C3BusinessLogic
//{
//    public class TipoDireccionATBL
//    {
//        readonly C2AccessGenericIGeneric<TipoDireccionAT> modeloTipoDireccion = new C2AccessGenericGeneric<TipoDireccionAT>();


//        public void insertarTipoDireccion(TipoDireccionAT IdTipoDireccion)
//        {
           
//            try
//            {
//                modeloTipoDireccion.Add(IdTipoDireccion);
//                modeloTipoDireccion.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error al insertar el tipo de direccion");
//            }
//        }

//        public void actualizarTipoDireccion(TipoDireccionAT IdTipoDireccion)
//        {
//            var tipodireccionExiste = modeloTipoDireccion.GetById(IdTipoDireccion.Id_TipoDireccion);

//            try
//            {
//                tipodireccionExiste.Id_TipoDireccion = IdTipoDireccion.Id_TipoDireccion;
//                tipodireccionExiste.Descripcion = IdTipoDireccion.Descripcion;
//                tipodireccionExiste.Estado = IdTipoDireccion.Estado;
//                tipodireccionExiste.DireccionAT = IdTipoDireccion.DireccionAT;


//                modeloTipoDireccion.Update(IdTipoDireccion);
//                modeloTipoDireccion.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error al insertar el tipo de direccion");
//            }
//        }

//        public void eliminarTipoDireccion(int IdTipoDireccion)
//        {
            

//            try
//            {
//                var tipodireccionExiste = modeloTipoDireccion.GetById(IdTipoDireccion);

//                if (tipodireccionExiste == null)
//                {
//                    throw new Exception("Error: El tipo de direccion con el ID especificado no existe");
//                }

//                modeloTipoDireccion.HardDelete(tipodireccionExiste);
//                modeloTipoDireccion.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error al eliminar el tipo direccion. " + ex.Message, ex);
//            }
//        }

//        public TipoDireccionAT buscarTipoDireccionPorId(int IdTipoDireccion)
//        {
//            try
//            {
//                var tipodireccionExiste = modeloTipoDireccion.GetById(IdTipoDireccion);

//                if (tipodireccionExiste == null)
//                {
//                    throw new Exception("Error: El tipo de direccion con el ID especificado no existe");
//                }

//                return tipodireccionExiste;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error al eliminar el tipo direccion. " + ex.Message, ex);
//            }
//        }

//        public List<TipoDireccionAT> imprimirTipoDireccion()
//        {
//            try
//            {
//                IQueryable<TipoDireccionAT> list = modeloTipoDireccion.GetAll();
//                return list.ToList();
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error al obtener los tipos de direcciones. " + ex.Message, ex);
//            }
//        }

//    }
//}

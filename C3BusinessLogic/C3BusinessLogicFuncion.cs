using FinalGrupal.C1Model;
using FinalGrupal.C2DataAccess.C2AccessGeneric;

namespace FinalGrupal.C3BusinessLogic
{
    internal class C3BusinessLogicFuncion
    {
        readonly C2AccessGenericGeneric<C1ModelPerfil> modeloPerfil = new C2AccessGenericGeneric<C1ModelPerfil>();
        readonly C2AccessGenericGeneric<C1ModelFuncion> modeloFuncion = new C2AccessGenericGeneric<C1ModelFuncion>();

        public void insertarFuncion(C1ModelFuncion IdFuncion)
        {
            try
            {
                // La funcion existe, procede a realizar la insercion
                modeloFuncion.Add(IdFuncion);
                modeloFuncion.SaveChanges();
            }
            catch (Exception ex)
            {
                // Se lanza una excepcion en caso de ocurira algun error en la insercion
                throw new Exception("Error al insertar la funcion");
            }
        }

        public void actualizarFuncion(C1ModelFuncion IdFuncion)
        {
            var funcionExiste = modeloFuncion.GetById(IdFuncion.IdFuncion);
            try
            {
                // Actualiza los campos de funcion
                funcionExiste.NombreFuncion = IdFuncion.NombreFuncion;
                funcionExiste.DescripcionFuncion = IdFuncion.DescripcionFuncion;

                modeloFuncion.Update(funcionExiste);
                modeloFuncion.SaveChanges();
            }
            catch (Exception ex)
            {
                // Lanzar la excepción hacia la capa de presentación
                throw new Exception("Error al actualizar la funcion: " + ex.Message, ex);
            }
        }

        public void eliminarFuncion(int IdFuncion) 
        {
            try
            {
                var funcionExiste = modeloFuncion.GetById(IdFuncion);

                if (funcionExiste == null)
                {
                    throw new Exception("Error: La funcion con el ID especificado no existe");
                }

                modeloFuncion.HardDelete(funcionExiste);
                modeloFuncion.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la funcion. " + ex.Message, ex);
            }
        }

        public C1ModelFuncion buscarFuncionPorId(int IdFuncion)
        {
            try
            {
                var funcionExiste = modeloFuncion.GetById(IdFuncion);

                if (funcionExiste == null)
                {
                    throw new Exception("Error: La funcion con el ID especificado no existe");
                }

                return funcionExiste;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar la funcion. " + ex.Message, ex);
            }
        }

        public List<C1ModelFuncion> imprimirFuncion()
        {
            try
            {
                IQueryable<C1ModelFuncion> list = modeloFuncion.GetAll();
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las funciones. " + ex.Message, ex);
            }
        }

    }
}

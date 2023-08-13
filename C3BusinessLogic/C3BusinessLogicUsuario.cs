using AppWebSistemaClinica.C1Model;
using AppWebSistemaClinica.C2DataAccess.C2AccessGeneric;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AppWebSistemaClinica.C3BusinessLogic
{
    public class C3BusinessLogicUsuario
    {
        readonly C2AccessGenericGeneric<C1ModelUsuario> modeloUsuario = new C2AccessGenericGeneric<C1ModelUsuario>();
        readonly C2AccessGenericGeneric<C1ModelPerfil> modeloPerfil = new C2AccessGenericGeneric<C1ModelPerfil>();

        public void insertarUsuario(C1ModelUsuario IdUsuario)
        {
            try
            {
                // El usuario existe, procede a realizar la insercion
                modeloUsuario.Add(IdUsuario);
                modeloUsuario.SaveChanges();
            }
            catch (Exception ex)
            {
                // Se lanza una excepcion en caso de ocurira algun error en la insercion
                throw new Exception("Error al insertar el usuario");
            }
        }

        public void actualizarUsuario(C1ModelUsuario IdUsuario)
        {
            var usuarioExiste = modeloUsuario.GetById(IdUsuario.IdUsuario);
            try
            {
                // Actualiza los campos de funcion
                usuarioExiste.NombreUsuario = IdUsuario.NombreUsuario;
                usuarioExiste.ContrasenaUsuario = IdUsuario.ContrasenaUsuario;

                modeloUsuario.Update(usuarioExiste);
                modeloUsuario.SaveChanges();
            }
            catch (Exception ex)
            {
                // Lanzar la excepción hacia la capa de presentación
                throw new Exception("Error al actualizar el usuario: " + ex.Message, ex);
            }
        }

        public void eliminarUsuario(int IdUsuario)
        {
            try
            {
                var usuarioExiste = modeloUsuario.GetById(IdUsuario);

                if (usuarioExiste == null)
                {
                    throw new Exception("Error: El usuario con el ID especificado no existe");
                }

                modeloUsuario.HardDelete(usuarioExiste);
                modeloUsuario.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el usuario. " + ex.Message, ex);
            }
        }

        public C1ModelUsuario buscarUsuarioPorId(int IdUsuario)
        {
            try
            {
                var usuarioExiste = modeloUsuario.GetById(IdUsuario);

                if (usuarioExiste == null)
                {
                    throw new Exception("Error: El usuario con el ID especificado no existe");
                }

                return usuarioExiste;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el usuario. " + ex.Message, ex);
            }
        }

        public List<C1ModelUsuario> imprimirUsuario()
        {
            try
            {
                IQueryable<C1ModelUsuario> list = modeloUsuario.GetAll();
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los usuarios. " + ex.Message, ex);
            }
        }

        internal bool eliminarUsuario()
        {
            throw new NotImplementedException();
        }
    }
}
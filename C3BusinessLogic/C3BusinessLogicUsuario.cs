using AppWebSistemaClinica.C1Model;
using AppWebSistemaClinica.C2DataAccess;
using AppWebSistemaClinica.C2DataAccess.C2AccessGeneric;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Security.Cryptography;
using System.Text;

namespace AppWebSistemaClinica.C3BusinessLogic
{
    public class C3BusinessLogicUsuario
    {
        readonly C2AccessGenericGeneric<C1ModelUsuario> modeloUsuario = new C2AccessGenericGeneric<C1ModelUsuario>();
        readonly C2AccessGenericGeneric<C1ModelPerfil> modeloPerfil = new C2AccessGenericGeneric<C1ModelPerfil>();


        private string GenerarHashContraseña(string contraseña)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseña));
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        private C2DataAccessUsuario userDataAccess = new C2DataAccessUsuario(); // Supongo que tienes una instancia de la capa de acceso a datos aquí.
        public C1ModelUsuario buscarUsuarioPorCorreo(string correo)
        {
            return userDataAccess.BuscarUsuarioPorCorreo(correo);
        }


        public void insertarUsuario(C1ModelUsuario IdUsuario)
        {
            try
            {
                IdUsuario.ContrasenaUsuario = GenerarHashContraseña(IdUsuario.ContrasenaUsuario);
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
using AppWebSistemaClinica.C1Model;
using AppWebSistemaClinica.C2DataAccess;
using AppWebSistemaClinica.C2DataAccess.C2AccessGeneric;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;

namespace AppWebSistemaClinica.C3BusinessLogic
{
    public class C3BusinessLogicPerfil
    {
        readonly C2AccessGenericIGeneric<C1ModelPerfil> modeloPerfil = new C2AccessGenericGeneric<C1ModelPerfil>();
        readonly C2AccessGenericIGeneric<C1ModelRol> modeloRol = new C2AccessGenericGeneric<C1ModelRol>();
        readonly C2AccessGenericIGeneric<C1ModelUsuario> modeloUsuario = new C2AccessGenericGeneric<C1ModelUsuario>();

        public void insertarPerfil(C1ModelPerfil IdPerfil)
        {
            // Verifica si el modelo, rol y usuario con el IdPerfil especificado existe
            bool rolExiste = modeloRol.Exists(c => c.IdRol == IdPerfil.IdRol);
            bool usuarioExiste = modeloUsuario.Exists(c => c.IdUsuario == IdPerfil.IdUsuario);

            if (!rolExiste)
            {
                // Si el rol no existe, lanza una excepcion con mensaje personalizado
                throw new ArgumentException("El rol con el ID especificado no existe. ");
            }

            if (!usuarioExiste)
            {
                // Si el usuario no existe, lanza una excepcion con mensaje personalizado
                throw new ArgumentException("El usuario con el ID especificado no existe. ");
            }

            try
            {
                // El perfil existe, procede a realizar la insercion
                modeloPerfil.Add(IdPerfil);
                modeloPerfil.SaveChanges();
            }
            catch (Exception ex)
            {
                // Se lanza una excepcion en caso de ocuriri algun error en la insercion
                throw new Exception("Error al insertar el perfil");
            }
        }

        public void actualizarPerfil(C1ModelPerfil IdPerfil)
        {
            var perfilExiste = modeloPerfil.GetById(IdPerfil.IdPerfil);
            bool rolExiste = modeloRol.Exists(c => c.IdRol == IdPerfil.IdRol);
            bool usuarioExiste = modeloUsuario.Exists(c => c.IdUsuario == IdPerfil.IdUsuario);

            
            if (!rolExiste)
            {
                // Si el rol no existe, lanza una excepcion con mensaje personalizado
                throw new ArgumentException("El rol con el ID especificado no existe. ");
            }

            if (!usuarioExiste)
            {
                // Si el usuario no existe, lanza una excepcion con mensaje personalizado
                throw new ArgumentException("El usuario con el ID especificado no existe. ");
            }

            if (perfilExiste == null)
            {
                // Si el usuario no existe, lanza una excepcion con mensaje personalizado
                throw new ArgumentException("El perfil con el ID especificado no existe. ");
            }

            try
            {
                // Actualiza los campos de perfil
                perfilExiste.IdRol = IdPerfil.IdRol;
                perfilExiste.IdUsuario = IdPerfil.IdUsuario;

                modeloPerfil.Update(perfilExiste);
                modeloPerfil.SaveChanges();
            }
            catch (Exception ex)
            {
                // Lanzar la excepción hacia la capa de presentación
                throw new Exception("Error al actualizar el perfil: " + ex.Message, ex);
            }

        }

        public void eliminarPerfil(int IdPerfil)
        {
            try
            {
                var perfilExiste = modeloPerfil.GetById(IdPerfil);

                if(perfilExiste == null)
                {
                    throw new Exception("Error: El perfil con el ID especificado no existe");
                }

                modeloPerfil.HardDelete(perfilExiste);
                modeloPerfil.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception("Error al eliminar el perfil. " + ex.Message, ex);
            }
        }

        public C1ModelPerfil buscarPerfilPorId(int IdPerfil)
        {
            try
            {
                var perfilExiste = modeloPerfil.GetById(IdPerfil);

                if (perfilExiste == null)
                {
                    throw new Exception("Error: El perfil con el ID especificado no existe");
                }

                return perfilExiste;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el perfil. " + ex.Message, ex);
            }
        }

        public List<C1ModelPerfil> imprimirPerfiles()
        {
            try
            {
                IQueryable<C1ModelPerfil> list = modeloPerfil.GetAll();
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los perfiles. " + ex.Message, ex);
            }

        }


        


    }
}

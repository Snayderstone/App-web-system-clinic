using AppWebSistemaClinica.C1Model;
using AppWebSistemaClinica.C2DataAccess.C2AccessGeneric;
using Microsoft.EntityFrameworkCore;

namespace AppWebSistemaClinica.C3BusinessLogic
{
    public class C3BusinessLogicUsuarioPerfilRol
    {
    readonly C2AccessGenericIGeneric<C1ModelPerfil> modeloPerfil = new C2AccessGenericGeneric<C1ModelPerfil>();
    readonly C2AccessGenericIGeneric<C1ModelRol> modeloRol = new C2AccessGenericGeneric<C1ModelRol>();
    readonly C2AccessGenericIGeneric<C1ModelUsuario> modeloUsuario = new C2AccessGenericGeneric<C1ModelUsuario>();

        //Joins perfil ususario rol apra acceder a esos objetos
        //METODOS PARA JOINS user-perfil-rol
        public List<C1ModelPerfil> obtenerUsuariosPerfilesRolesEager()
        {
            try
            {
                IQueryable<C1ModelPerfil> listaPerfiles = modeloPerfil.GetAll()
                        .Include(p => p.C1ModelRol)
                        .Include(p => p.C1ModelUsuario);

                return listaPerfiles.ToList();
            }
            catch (Exception ex)
            {
                // Lanzar la excepción hacia la capa de presentación
                throw new Exception("Error al obtener perfiles: " + ex.Message, ex);
            }
        }

    }
}

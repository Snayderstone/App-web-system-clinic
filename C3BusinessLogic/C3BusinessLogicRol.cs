using AppWebSistemaClinica.C1Model;
using AppWebSistemaClinica.C2DataAccess.C2AccessGeneric;
using Microsoft.Identity.Client;

namespace AppWebSistemaClinica.C3BusinessLogic
{
    internal class C3BusinessLogicRol
    {
        readonly C2AccessGenericGeneric<C1ModelRol> modeloRol = new C2AccessGenericGeneric<C1ModelRol>();
        readonly C2AccessGenericGeneric<C1ModelPerfil> modeloPerfil = new C2AccessGenericGeneric<C1ModelPerfil>();

        public void insertarRol(C1ModelRol IdRol)
        {
            try
            {
                // El perfil existe, procede a realizar la insercion
                modeloRol.Add(IdRol);
                modeloRol.SaveChanges();
            }
            catch (Exception ex)
            {
                // Se lanza una excepcion en caso de ocuriri algun error en la insercion
                throw new Exception("Error al insertar el rol");
            }

        }

        public void actualizarRol(C1ModelRol IdRol)
        {
            var rolExiste = modeloRol.GetById(IdRol.IdRol);

            try
            {
                rolExiste.NombreRol = IdRol.NombreRol;
                rolExiste.DescripcionRol = IdRol.DescripcionRol;

                modeloRol.Update(rolExiste);
                modeloRol.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el rol: " + ex.Message, ex);
            }

        }

        public void eliminarRol(int IdRol)
        {
            try
            {
                var rolExiste = modeloRol.GetById(IdRol);

                if (rolExiste == null)
                {
                    throw new Exception("Error: El rol con el ID especificado no existe");
                }

                modeloRol.HardDelete(rolExiste);
                modeloRol.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el rol. " + ex.Message, ex);
            }
        }

        public C1ModelRol buscarRolPorId(int IdRol)
        {
            try
            {
                var rolExiste = modeloRol.GetById(IdRol);

                if (rolExiste == null)
                {
                    throw new Exception("Error: El rol con el ID especificado no existe");
                }

                return rolExiste;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el rol. " + ex.Message, ex);
            }
        }

        public List<C1ModelRol> imprimirRoles() 
        {
            try
            {
                IQueryable<C1ModelRol> list = modeloRol.GetAll();
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los roles. " + ex.Message, ex);
            }
        
        }

    }
}

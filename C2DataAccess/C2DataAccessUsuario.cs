using AppWebSistemaClinica.C1Model;
using AppWebSistemaClinica.C1Model.C1ModelContext;
using AppWebSistemaClinica.C2DataAccess.C2AccessGeneric;

namespace AppWebSistemaClinica.C2DataAccess
{
    internal class C2DataAccessUsuario : C2AccessGenericGeneric<C2DataAccessUsuario>
    {
       // nuevo contexto para el metodo propio para CORREO
        public C1ModelContextContexto contexto2 = new C1ModelContextContexto();

        public C1ModelUsuario BuscarUsuarioPorCorreo(string correoUser)
        {
            var correoEncontrado = contexto2.USUARIOS.FirstOrDefault(c => c.CorreoElectronico == correoUser);
            return correoEncontrado;
        }

        //nuevo contexto para el metodo propio para color
        //public C1MODContexto contexto2 = new C1MODContexto();

        //public C1MODColor ColorPorNombre(string nombreColor)
        //{
        //    var colorEncontrado = contexto2.COLORES.FirstOrDefault(c => c.NombreColor == nombreColor);
        //    return colorEncontrado;
        //}

        //para el busines logic
        //Para implementar metodo propio del objeto

        //private C2DAColor colorDataAccess = new C2DAColor(); // Supongo que tienes una instancia de la capa de acceso a datos aquí.

        //public C1MODColor BuscarColorPorNombre(string nombreColor)
        //{
        //    return colorDataAccess.ColorPorNombre(nombreColor);
        //}

        //para la capa de presentacion
        //metodo propio de color
        //public void BuscarColorPorNombre()
        //{
        //    Console.WriteLine("Buscando color por nombre...");

        //    string nombreColor;
        //    do
        //    {
        //        Console.Write("Ingrese el nombre del color: ");
        //        nombreColor = Console.ReadLine();

        //        if (!Validaciones.EsNombreValido(nombreColor))
        //        {
        //            Console.WriteLine("Error: El nombre del color no es válido.");
        //        }
        //    } while (!Validaciones.EsNombreValido(nombreColor));

        //    try
        //    {
        //        var colorEncontrado = colorLogic.BuscarColorPorNombre(nombreColor);
        //        if (colorEncontrado != null)
        //        {
        //            Console.WriteLine("  ID|Nombre");
        //            Console.WriteLine($"{colorEncontrado.IdColor,4}|{colorEncontrado.NombreColor}");
        //        }
        //        else
        //        {
        //            Console.WriteLine("El color no fue encontrado.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Aquí capturamos la excepción y decidimos cómo manejarla en esta capa.
        //        // Puedes mostrar mensajes de error al usuario, registrar la excepción en un log, etc.
        //        Console.WriteLine("Error al buscar el color por nombre: " + ex.Message);
        //    }
        //}
        //JOINS

    }
}


using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AppWebSistemaClinica.C1Model.C1ModelContext
{
    public class C1ModelContextContexto:DbContext
    {

        public C1ModelContextContexto()
        {
        }

        public C1ModelContextContexto(DbContextOptions<C1ModelContextContexto> options)
            : base(options)
        {
        }

        //Color es la clase en el modelo y COLORES es la entidad en la bd que se va a generar
        //uno a muchos

        //internal virtual DbSet<C1ModelCliente> CLIENTES { get; set; }
        //internal virtual DbSet<C1ModelFactura> FACTURAS { get; set; }
        //internal virtual DbSet<C1ModelVenta> VENTAS { get; set; }
        //internal virtual DbSet<C1ModelProducto> PRODUCTOS { get; set; }
        //internal virtual DbSet<C1ModelCategoria> CATEGORIAS { get; set; }
        //internal virtual DbSet<C1ModelProveedor> PROVEEDORES { get; set; }
        //internal virtual DbSet<C1ModelPais> PAISES { get; set; }
        //internal virtual DbSet<C1ModelProvincia> PROVINCIAS { get; set; }

        //Microsoft.Extensions.Configuration.FileExtensions
        //Microsoft.Extensions.Configuration.Json
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("Y:\\Proyectos de VS Community\\100 PROYECTOFINAL\\AppWebSistemaClinica\\appsettings.json")
                    .Build();
                string connectionString = configuration.GetConnectionString("MyConnectionString");

                optionsBuilder.UseSqlServer(connectionString);
            }
            catch (Exception ex)
            {
                // Lanza una excepción personalizada cuando ocurre un error en la configuración de la base de datos
                throw new Exception("Error al configurar la conexión a la base de datos: " + ex.Message, ex);
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace AppWebSistemaClinica.C1Model.C1ModelContext
{
    public class C1ModelContextContexto : DbContext
    {

        public C1ModelContextContexto()
        {
        }

        public C1ModelContextContexto(DbContextOptions<C1ModelContextContexto> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<C1ModelEquipoMedicoClinica>().HasKey(x => new { x.IdEquipoMedico, x.IdClinica });
        }


        public virtual DbSet<C1ModelUsuario> USUARIOS { get; set; }
        public virtual DbSet<C1ModelPerfil> PERFILES { get; set; }
        public virtual DbSet<C1ModelRol> ROLES { get; set; }
        public virtual DbSet<C1ModelCita> CITAS { get; set; }
        public virtual DbSet<C1ModelPago> PAGOS { get; set; }
        public virtual DbSet<C1ModelPaciente> PACIENTES { get; set; }
        public virtual DbSet<C1ModelFactura> FACTURAS { get; set; }
        public virtual DbSet<C1ModelClinica> CLINICAS { get; set; }
        public virtual DbSet<C1ModelMedico> MEDICOS { get; set; }
        public virtual DbSet<C1ModelRegistroMedico> REGISTROSMEDICOS { get; set; }
        public virtual DbSet<C1ModelHistorialClinico> HISTORIALESCLINICOS { get; set; }
        public virtual DbSet<C1ModelEquipoMedico> EQUIPOSMEDICOS { get; set; }
        public virtual DbSet<C1ModelEquipoMedicoClinica> EQUIPOSMEDICOSCLINICAS { get; set; }
        public virtual DbSet<C1ModelEspecialidad> ESPECIALIDADES { get; set; }
        
        
        
        
        public virtual DbSet<C1ModelDetalleFactura> DETALLESFACTURAS { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("Y:\\Proyectos de VS Community\\100 PROYECTOFINAL\\AppWebSistemaClinica\\C1Model\\appsettings.json")
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

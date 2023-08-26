using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppWebSistemaClinica.Migrations
{
    /// <inheritdoc />
    public partial class m10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLINICAS",
                columns: table => new
                {
                    IdClinica = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreClinica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapacidadClinica = table.Column<int>(type: "int", nullable: false),
                    UbicacionClinica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecioConsultaClinica = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLINICAS", x => x.IdClinica);
                });

            migrationBuilder.CreateTable(
                name: "EQUIPOSMEDICOS",
                columns: table => new
                {
                    IdEquipoMedico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEquipoMedico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionEquipoMedico = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EQUIPOSMEDICOS", x => x.IdEquipoMedico);
                });

            migrationBuilder.CreateTable(
                name: "ESPECIALIDADES",
                columns: table => new
                {
                    IdEspecialidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionEspecialidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecioEspecialidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESPECIALIDADES", x => x.IdEspecialidad);
                });

            migrationBuilder.CreateTable(
                name: "PACIENTES",
                columns: table => new
                {
                    idPaciente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePaciente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoPaciente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CedulaPaciente = table.Column<int>(type: "int", nullable: false),
                    FechaNacimientoPaciente = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EdadPaciente = table.Column<int>(type: "int", nullable: false),
                    TelefonoPaciente = table.Column<int>(type: "int", nullable: false),
                    CorreoPaciente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoCivilPaciente = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PACIENTES", x => x.idPaciente);
                });

            migrationBuilder.CreateTable(
                name: "PAGOS",
                columns: table => new
                {
                    IdPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormaPago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionPago = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAGOS", x => x.IdPago);
                });

            migrationBuilder.CreateTable(
                name: "ROLES",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionRol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLES", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContrasenaUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "EQUIPOSMEDICOSCLINICAS",
                columns: table => new
                {
                    IdEquipoMedico = table.Column<int>(type: "int", nullable: false),
                    IdClinica = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EQUIPOSMEDICOSCLINICAS", x => new { x.IdEquipoMedico, x.IdClinica });
                    table.ForeignKey(
                        name: "FK_EQUIPOSMEDICOSCLINICAS_CLINICAS_IdClinica",
                        column: x => x.IdClinica,
                        principalTable: "CLINICAS",
                        principalColumn: "IdClinica",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EQUIPOSMEDICOSCLINICAS_EQUIPOSMEDICOS_IdEquipoMedico",
                        column: x => x.IdEquipoMedico,
                        principalTable: "EQUIPOSMEDICOS",
                        principalColumn: "IdEquipoMedico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MEDICOS",
                columns: table => new
                {
                    IdMedico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreMedico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoMedico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoMedico = table.Column<int>(type: "int", nullable: false),
                    CorreoMedico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HorarioMedico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEspecialidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEDICOS", x => x.IdMedico);
                    table.ForeignKey(
                        name: "FK_MEDICOS_ESPECIALIDADES_IdEspecialidad",
                        column: x => x.IdEspecialidad,
                        principalTable: "ESPECIALIDADES",
                        principalColumn: "IdEspecialidad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HISTORIALESCLINICOS",
                columns: table => new
                {
                    Id_HistorialClinico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionHisClinico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotasMedicasHisClinico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListEnfermedadesRecientHisClinico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HISTORIALESCLINICOS", x => x.Id_HistorialClinico);
                    table.ForeignKey(
                        name: "FK_HISTORIALESCLINICOS_PACIENTES_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "PACIENTES",
                        principalColumn: "idPaciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FACTURAS",
                columns: table => new
                {
                    IdFactura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MontoTotalFctura = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstadoPagoFactura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaFactura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    IdPago = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FACTURAS", x => x.IdFactura);
                    table.ForeignKey(
                        name: "FK_FACTURAS_PACIENTES_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "PACIENTES",
                        principalColumn: "idPaciente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FACTURAS_PAGOS_IdPago",
                        column: x => x.IdPago,
                        principalTable: "PAGOS",
                        principalColumn: "IdPago",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PERFILES",
                columns: table => new
                {
                    IdPerfil = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERFILES", x => x.IdPerfil);
                    table.ForeignKey(
                        name: "FK_PERFILES_ROLES_IdRol",
                        column: x => x.IdRol,
                        principalTable: "ROLES",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PERFILES_USUARIOS_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "USUARIOS",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CITAS",
                columns: table => new
                {
                    IdCita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraInicioCita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraFinCita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoCita = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdMedico = table.Column<int>(type: "int", nullable: false),
                    IdClinica = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CITAS", x => x.IdCita);
                    table.ForeignKey(
                        name: "FK_CITAS_CLINICAS_IdClinica",
                        column: x => x.IdClinica,
                        principalTable: "CLINICAS",
                        principalColumn: "IdClinica",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CITAS_MEDICOS_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "MEDICOS",
                        principalColumn: "IdMedico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "REGISTROSMEDICOS",
                columns: table => new
                {
                    IdRegistroMedico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DetallesRegistroMedico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdHistorialClinico = table.Column<int>(type: "int", nullable: false),
                    C1ModelHistorialClinicoId_HistorialClinico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REGISTROSMEDICOS", x => x.IdRegistroMedico);
                    table.ForeignKey(
                        name: "FK_REGISTROSMEDICOS_HISTORIALESCLINICOS_C1ModelHistorialClinicoId_HistorialClinico",
                        column: x => x.C1ModelHistorialClinicoId_HistorialClinico,
                        principalTable: "HISTORIALESCLINICOS",
                        principalColumn: "Id_HistorialClinico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DETALLESFACTURAS",
                columns: table => new
                {
                    IdDetalleFactura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionDetalleFactura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecioUnitarioDetalleFactura = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IvaDetalleFactura = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtroImpuesto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecioTotalDetalleFactura = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdCita = table.Column<int>(type: "int", nullable: false),
                    IdFactura = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DETALLESFACTURAS", x => x.IdDetalleFactura);
                    table.ForeignKey(
                        name: "FK_DETALLESFACTURAS_CITAS_IdCita",
                        column: x => x.IdCita,
                        principalTable: "CITAS",
                        principalColumn: "IdCita",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DETALLESFACTURAS_FACTURAS_IdFactura",
                        column: x => x.IdFactura,
                        principalTable: "FACTURAS",
                        principalColumn: "IdFactura",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CITAS_IdClinica",
                table: "CITAS",
                column: "IdClinica");

            migrationBuilder.CreateIndex(
                name: "IX_CITAS_IdMedico",
                table: "CITAS",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_DETALLESFACTURAS_IdCita",
                table: "DETALLESFACTURAS",
                column: "IdCita");

            migrationBuilder.CreateIndex(
                name: "IX_DETALLESFACTURAS_IdFactura",
                table: "DETALLESFACTURAS",
                column: "IdFactura");

            migrationBuilder.CreateIndex(
                name: "IX_EQUIPOSMEDICOSCLINICAS_IdClinica",
                table: "EQUIPOSMEDICOSCLINICAS",
                column: "IdClinica");

            migrationBuilder.CreateIndex(
                name: "IX_FACTURAS_IdPaciente",
                table: "FACTURAS",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_FACTURAS_IdPago",
                table: "FACTURAS",
                column: "IdPago");

            migrationBuilder.CreateIndex(
                name: "IX_HISTORIALESCLINICOS_IdPaciente",
                table: "HISTORIALESCLINICOS",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_MEDICOS_IdEspecialidad",
                table: "MEDICOS",
                column: "IdEspecialidad");

            migrationBuilder.CreateIndex(
                name: "IX_PERFILES_IdRol",
                table: "PERFILES",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_PERFILES_IdUsuario",
                table: "PERFILES",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_REGISTROSMEDICOS_C1ModelHistorialClinicoId_HistorialClinico",
                table: "REGISTROSMEDICOS",
                column: "C1ModelHistorialClinicoId_HistorialClinico");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DETALLESFACTURAS");

            migrationBuilder.DropTable(
                name: "EQUIPOSMEDICOSCLINICAS");

            migrationBuilder.DropTable(
                name: "PERFILES");

            migrationBuilder.DropTable(
                name: "REGISTROSMEDICOS");

            migrationBuilder.DropTable(
                name: "CITAS");

            migrationBuilder.DropTable(
                name: "FACTURAS");

            migrationBuilder.DropTable(
                name: "EQUIPOSMEDICOS");

            migrationBuilder.DropTable(
                name: "ROLES");

            migrationBuilder.DropTable(
                name: "USUARIOS");

            migrationBuilder.DropTable(
                name: "HISTORIALESCLINICOS");

            migrationBuilder.DropTable(
                name: "CLINICAS");

            migrationBuilder.DropTable(
                name: "MEDICOS");

            migrationBuilder.DropTable(
                name: "PAGOS");

            migrationBuilder.DropTable(
                name: "PACIENTES");

            migrationBuilder.DropTable(
                name: "ESPECIALIDADES");
        }
    }
}

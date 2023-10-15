using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendEncuesta.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComunasResidencia",
                columns: table => new
                {
                    ComunaResidenciaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComunasResidencia", x => x.ComunaResidenciaId);
                });

            migrationBuilder.CreateTable(
                name: "ComunasTrabajo",
                columns: table => new
                {
                    ComunaTrabajoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComunasTrabajo", x => x.ComunaTrabajoId);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "ModalidadTrabajos",
                columns: table => new
                {
                    ModalidadTrabajoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModalidadTrabajos", x => x.ModalidadTrabajoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoTransportes",
                columns: table => new
                {
                    TipoTransporteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comparte = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTransportes", x => x.TipoTransporteId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    usuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trabaja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    recuperar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModalidadTrabajoId = table.Column<int>(type: "int", nullable: false),
                    ComunaResidenciaId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    ComunaTrabajoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.usuarioId);
                    table.ForeignKey(
                        name: "FK_Usuarios_ComunasResidencia_ComunaResidenciaId",
                        column: x => x.ComunaResidenciaId,
                        principalTable: "ComunasResidencia",
                        principalColumn: "ComunaResidenciaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_ComunasTrabajo_ComunaTrabajoId",
                        column: x => x.ComunaTrabajoId,
                        principalTable: "ComunasTrabajo",
                        principalColumn: "ComunaTrabajoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_ModalidadTrabajos_ModalidadTrabajoId",
                        column: x => x.ModalidadTrabajoId,
                        principalTable: "ModalidadTrabajos",
                        principalColumn: "ModalidadTrabajoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Encuestas",
                columns: table => new
                {
                    EncuestaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecharealizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pregunta1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pregunta2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pregunta3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pregunta4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pregunta5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pregunta6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoTransporteId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encuestas", x => x.EncuestaId);
                    table.ForeignKey(
                        name: "FK_Encuestas_TipoTransportes_TipoTransporteId",
                        column: x => x.TipoTransporteId,
                        principalTable: "TipoTransportes",
                        principalColumn: "TipoTransporteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Encuestas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "usuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Encuestas_TipoTransporteId",
                table: "Encuestas",
                column: "TipoTransporteId");

            migrationBuilder.CreateIndex(
                name: "IX_Encuestas_UsuarioId",
                table: "Encuestas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ComunaResidenciaId",
                table: "Usuarios",
                column: "ComunaResidenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ComunaTrabajoId",
                table: "Usuarios",
                column: "ComunaTrabajoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EstadoId",
                table: "Usuarios",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ModalidadTrabajoId",
                table: "Usuarios",
                column: "ModalidadTrabajoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Encuestas");

            migrationBuilder.DropTable(
                name: "TipoTransportes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "ComunasResidencia");

            migrationBuilder.DropTable(
                name: "ComunasTrabajo");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "ModalidadTrabajos");
        }
    }
}

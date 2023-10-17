using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendEncuesta.Migrations
{
    /// <inheritdoc />
    public partial class _161020232248 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ComunasResidencia_ComunaResidenciaId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ComunasTrabajo_ComunaTrabajoId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Estados_EstadoId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ModalidadTrabajos_ModalidadTrabajoId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ComunaResidenciaId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ComunaTrabajoId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EstadoId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ModalidadTrabajoId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ComunaResidenciaId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ComunaTrabajoId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ModalidadTrabajoId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "apellidos",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "nombres",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "recuperar",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "rut",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "trabaja",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Encuestas",
                newName: "UsuarioId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Encuestas_Usuarios_UsuarioId",
                table: "Encuestas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "usuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Encuestas_Usuarios_UsuarioId",
                table: "Encuestas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Encuestas_UsuarioId",
                table: "Encuestas");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Encuestas",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "ComunaResidenciaId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ComunaTrabajoId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModalidadTrabajoId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "apellidos",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "nombres",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "recuperar",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "rut",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "trabaja",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ComunaResidenciaId",
                table: "AspNetUsers",
                column: "ComunaResidenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ComunaTrabajoId",
                table: "AspNetUsers",
                column: "ComunaTrabajoId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EstadoId",
                table: "AspNetUsers",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ModalidadTrabajoId",
                table: "AspNetUsers",
                column: "ModalidadTrabajoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ComunasResidencia_ComunaResidenciaId",
                table: "AspNetUsers",
                column: "ComunaResidenciaId",
                principalTable: "ComunasResidencia",
                principalColumn: "ComunaResidenciaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ComunasTrabajo_ComunaTrabajoId",
                table: "AspNetUsers",
                column: "ComunaTrabajoId",
                principalTable: "ComunasTrabajo",
                principalColumn: "ComunaTrabajoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Estados_EstadoId",
                table: "AspNetUsers",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "EstadoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ModalidadTrabajos_ModalidadTrabajoId",
                table: "AspNetUsers",
                column: "ModalidadTrabajoId",
                principalTable: "ModalidadTrabajos",
                principalColumn: "ModalidadTrabajoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

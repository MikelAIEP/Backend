using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendEncuesta.Migrations
{
    /// <inheritdoc />
    public partial class userb2 : Migration
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
                name: "recuperar",
                table: "Usuarios");

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "recuperar",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "recuperar",
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

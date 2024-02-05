using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class EliminaColumnLKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vuelos_Usuarios_UsuarioActualizacionId",
                table: "Vuelos");

            migrationBuilder.DropForeignKey(
                name: "FK_Vuelos_Usuarios_UsuarioCreacioId",
                table: "Vuelos");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "Vuelos");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "Ciudades");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "Aereolinias");

            migrationBuilder.AddForeignKey(
                name: "FK_Vuelos_Usuarios_UsuarioActualizacionId",
                table: "Vuelos",
                column: "UsuarioActualizacionId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Vuelos_Usuarios_UsuarioCreacioId",
                table: "Vuelos",
                column: "UsuarioCreacioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vuelos_Usuarios_UsuarioActualizacionId",
                table: "Vuelos");

            migrationBuilder.DropForeignKey(
                name: "FK_Vuelos_Usuarios_UsuarioCreacioId",
                table: "Vuelos");

            migrationBuilder.AddColumn<int>(
                name: "Key",
                table: "Vuelos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Key",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Key",
                table: "Ciudades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Key",
                table: "Aereolinias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Vuelos_Usuarios_UsuarioActualizacionId",
                table: "Vuelos",
                column: "UsuarioActualizacionId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vuelos_Usuarios_UsuarioCreacioId",
                table: "Vuelos",
                column: "UsuarioCreacioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}

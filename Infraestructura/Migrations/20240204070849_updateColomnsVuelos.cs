using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class updateColomnsVuelos : Migration
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

            migrationBuilder.DropIndex(
                name: "IX_Vuelos_UsuarioCreacioId",
                table: "Vuelos");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacioId",
                table: "Vuelos");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_UsuarioCreacionId",
                table: "Vuelos",
                column: "UsuarioCreacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vuelos_Usuarios_UsuarioActualizacionId",
                table: "Vuelos",
                column: "UsuarioActualizacionId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vuelos_Usuarios_UsuarioCreacionId",
                table: "Vuelos",
                column: "UsuarioCreacionId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vuelos_Usuarios_UsuarioActualizacionId",
                table: "Vuelos");

            migrationBuilder.DropForeignKey(
                name: "FK_Vuelos_Usuarios_UsuarioCreacionId",
                table: "Vuelos");

            migrationBuilder.DropIndex(
                name: "IX_Vuelos_UsuarioCreacionId",
                table: "Vuelos");

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioCreacioId",
                table: "Vuelos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_UsuarioCreacioId",
                table: "Vuelos",
                column: "UsuarioCreacioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vuelos_Usuarios_UsuarioActualizacionId",
                table: "Vuelos",
                column: "UsuarioActualizacionId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vuelos_Usuarios_UsuarioCreacioId",
                table: "Vuelos",
                column: "UsuarioCreacioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

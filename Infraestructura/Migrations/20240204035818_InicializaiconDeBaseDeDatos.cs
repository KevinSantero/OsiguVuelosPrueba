using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class InicializaiconDeBaseDeDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aereolinias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Key = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aereolinias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Key = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Key = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vuelos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroVuelo = table.Column<int>(type: "int", nullable: false),
                    CiudadOrigenId = table.Column<int>(type: "int", nullable: false),
                    CiudadDestinoId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraSalida = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraLlegada = table.Column<TimeSpan>(type: "time", nullable: false),
                    AerolineaId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    UsuarioCreacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioActualizacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vuelos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vuelos_Aereolinias_AerolineaId",
                        column: x => x.AerolineaId,
                        principalTable: "Aereolinias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vuelos_Ciudades_CiudadDestinoId",
                        column: x => x.CiudadDestinoId,
                        principalTable: "Ciudades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vuelos_Ciudades_CiudadOrigenId",
                        column: x => x.CiudadOrigenId,
                        principalTable: "Ciudades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vuelos_Usuarios_UsuarioActualizacionId",
                        column: x => x.UsuarioActualizacionId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vuelos_Usuarios_UsuarioCreacioId",
                        column: x => x.UsuarioCreacioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_AerolineaId",
                table: "Vuelos",
                column: "AerolineaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_CiudadDestinoId",
                table: "Vuelos",
                column: "CiudadDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_CiudadOrigenId",
                table: "Vuelos",
                column: "CiudadOrigenId");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_UsuarioActualizacionId",
                table: "Vuelos",
                column: "UsuarioActualizacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_UsuarioCreacioId",
                table: "Vuelos",
                column: "UsuarioCreacioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vuelos");

            migrationBuilder.DropTable(
                name: "Aereolinias");

            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiStudentWork.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "licenciaConducir",
                columns: table => new
                {
                    licenciaConducirId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    licenciaConducirNombre = table.Column<string>(type: "nvarchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_licenciaConducir", x => x.licenciaConducirId);
                });

            migrationBuilder.CreateTable(
                name: "pais",
                columns: table => new
                {
                    paisId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    paisNombre = table.Column<string>(type: "nvarchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pais", x => x.paisId);
                });

            migrationBuilder.CreateTable(
                name: "paisDepartamento",
                columns: table => new
                {
                    paisDepartamentoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    paisDepartamentoNombre = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    pais_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paisDepartamento", x => x.paisDepartamentoId);
                    table.ForeignKey(
                        name: "FK_paisDepartamento_pais_pais_Id",
                        column: x => x.pais_Id,
                        principalTable: "pais",
                        principalColumn: "paisId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "paisCiudad",
                columns: table => new
                {
                    paisCiudadId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    paisCiudadNombre = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    paisDepartamento_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paisCiudad", x => x.paisCiudadId);
                    table.ForeignKey(
                        name: "FK_paisCiudad_paisDepartamento_paisDepartamento_Id",
                        column: x => x.paisDepartamento_Id,
                        principalTable: "paisDepartamento",
                        principalColumn: "paisDepartamentoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    usuarioId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    usuarioNombre = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    usuarioCorreo = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    usuarioContraseña = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    usuarioDNI = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    usuarioTelefono = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    usuarioSkype = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    usuarioDireccion = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    usuarioCodigoPostal = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    usuarioEstadoCivil = table.Column<string>(type: "char(1)", nullable: false),
                    usuarioVehiculoPropio = table.Column<string>(type: "char(1)", nullable: false),
                    usuarioGenero = table.Column<string>(type: "char(1)", nullable: false),
                    usuarioFechaNacimiento = table.Column<DateTime>(type: "date", nullable: false),
                    usuarioTimestamp = table.Column<DateTime>(rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    pais_Id = table.Column<int>(nullable: false),
                    paisDepartamento_Id = table.Column<int>(nullable: false),
                    paisCiudad_Id = table.Column<int>(nullable: false),
                    licenciaConducir_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.usuarioId);
                    table.ForeignKey(
                        name: "FK_usuario_licenciaConducir_licenciaConducir_Id",
                        column: x => x.licenciaConducir_Id,
                        principalTable: "licenciaConducir",
                        principalColumn: "licenciaConducirId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_usuario_paisCiudad_paisCiudad_Id",
                        column: x => x.paisCiudad_Id,
                        principalTable: "paisCiudad",
                        principalColumn: "paisCiudadId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_usuario_paisDepartamento_paisDepartamento_Id",
                        column: x => x.paisDepartamento_Id,
                        principalTable: "paisDepartamento",
                        principalColumn: "paisDepartamentoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_usuario_pais_pais_Id",
                        column: x => x.pais_Id,
                        principalTable: "pais",
                        principalColumn: "paisId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_paisCiudad_paisDepartamento_Id",
                table: "paisCiudad",
                column: "paisDepartamento_Id");

            migrationBuilder.CreateIndex(
                name: "IX_paisDepartamento_pais_Id",
                table: "paisDepartamento",
                column: "pais_Id");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_licenciaConducir_Id",
                table: "usuario",
                column: "licenciaConducir_Id");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_paisCiudad_Id",
                table: "usuario",
                column: "paisCiudad_Id");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_paisDepartamento_Id",
                table: "usuario",
                column: "paisDepartamento_Id");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_pais_Id",
                table: "usuario",
                column: "pais_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "licenciaConducir");

            migrationBuilder.DropTable(
                name: "paisCiudad");

            migrationBuilder.DropTable(
                name: "paisDepartamento");

            migrationBuilder.DropTable(
                name: "pais");
        }
    }
}

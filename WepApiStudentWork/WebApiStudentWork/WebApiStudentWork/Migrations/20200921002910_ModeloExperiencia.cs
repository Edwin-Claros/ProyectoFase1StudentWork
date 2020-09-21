using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiStudentWork.Migrations
{
    public partial class ModeloExperiencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "usuarioTimestamp",
                table: "usuario",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp(6)",
                oldNullable: true)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.CreateTable(
                name: "experiencia",
                columns: table => new
                {
                    experienciaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    experienciaEmpresa = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    experienciaDestacar = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    experienciaMejorar = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    experienciaSector = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    experienciaCargo = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    experienciaArea = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    experienciaFuncionesYLogros = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    experienciaFechaInicio = table.Column<DateTime>(type: "date", nullable: false),
                    experienciaFechaFinal = table.Column<DateTime>(type: "date", nullable: false),
                    experienciaRecomendacion = table.Column<string>(type: "char(1)", nullable: false),
                    usuario_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_experiencia", x => x.experienciaId);
                    table.ForeignKey(
                        name: "FK_experiencia_usuario_usuario_Id",
                        column: x => x.usuario_Id,
                        principalTable: "usuario",
                        principalColumn: "usuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_experiencia_usuario_Id",
                table: "experiencia",
                column: "usuario_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "experiencia");

            migrationBuilder.AlterColumn<DateTime>(
                name: "usuarioTimestamp",
                table: "usuario",
                type: "timestamp(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldRowVersion: true,
                oldNullable: true)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);
        }
    }
}

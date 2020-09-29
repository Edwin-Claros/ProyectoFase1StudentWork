using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiStudentWork.Migrations
{
    public partial class ModeloFormacionYAreaEstudio : Migration
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
                name: "AreaEstudio",
                columns: table => new
                {
                    areaEstudioId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    areaEstudioNombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaEstudio", x => x.areaEstudioId);
                });

            migrationBuilder.CreateTable(
                name: "Formacion",
                columns: table => new
                {
                    formacionId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    formacionCentroEducativo = table.Column<string>(nullable: true),
                    formacionAreaDeEstudio = table.Column<string>(nullable: true),
                    formacionNivelProfesorado = table.Column<string>(nullable: true),
                    formacionSatisfaccionprendizaje = table.Column<string>(nullable: true),
                    formacionAccesoAEmpleo = table.Column<string>(nullable: true),
                    formacionRecomendacion = table.Column<string>(nullable: false),
                    formacionEstado = table.Column<string>(nullable: false),
                    formacionFechaInicio = table.Column<DateTime>(nullable: false),
                    formacionFechaFinal = table.Column<DateTime>(nullable: false),
                    usuario_Id = table.Column<int>(nullable: false),
                    areaEstudio_Id = table.Column<int>(nullable: false),
                    usuarioId = table.Column<int>(nullable: true),
                    areaEstudioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formacion", x => x.formacionId);
                    table.ForeignKey(
                        name: "FK_Formacion_AreaEstudio_areaEstudioId",
                        column: x => x.areaEstudioId,
                        principalTable: "AreaEstudio",
                        principalColumn: "areaEstudioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Formacion_usuario_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "usuario",
                        principalColumn: "usuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Formacion_areaEstudioId",
                table: "Formacion",
                column: "areaEstudioId");

            migrationBuilder.CreateIndex(
                name: "IX_Formacion_usuarioId",
                table: "Formacion",
                column: "usuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Formacion");

            migrationBuilder.DropTable(
                name: "AreaEstudio");

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

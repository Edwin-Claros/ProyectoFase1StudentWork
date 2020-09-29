using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiStudentWork.Migrations
{
    public partial class ModelosIdioma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Formacion_AreaEstudio_areaEstudioId",
                table: "Formacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Formacion_usuario_usuarioId",
                table: "Formacion");

            migrationBuilder.DropTable(
                name: "AreaEstudio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Formacion",
                table: "Formacion");

            migrationBuilder.DropIndex(
                name: "IX_Formacion_areaEstudioId",
                table: "Formacion");

            migrationBuilder.DropIndex(
                name: "IX_Formacion_usuarioId",
                table: "Formacion");

            migrationBuilder.DropColumn(
                name: "areaEstudioId",
                table: "Formacion");

            migrationBuilder.DropColumn(
                name: "areaEstudio_Id",
                table: "Formacion");

            migrationBuilder.DropColumn(
                name: "usuarioId",
                table: "Formacion");

            migrationBuilder.RenameTable(
                name: "Formacion",
                newName: "formacion");

            migrationBuilder.AlterColumn<DateTime>(
                name: "usuarioTimestamp",
                table: "usuario",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp(6)",
                oldNullable: true)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<string>(
                name: "formacionSatisfaccionprendizaje",
                table: "formacion",
                type: "char(1)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1) CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "formacionRecomendacion",
                table: "formacion",
                type: "char(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1) CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "formacionNivelProfesorado",
                table: "formacion",
                type: "char(1)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1) CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "formacionFechaInicio",
                table: "formacion",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "formacionFechaFinal",
                table: "formacion",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<string>(
                name: "formacionEstado",
                table: "formacion",
                type: "char(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1) CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "formacionCentroEducativo",
                table: "formacion",
                type: "nvarchar(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "formacionAreaDeEstudio",
                table: "formacion",
                type: "nvarchar(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "formacionAccesoAEmpleo",
                table: "formacion",
                type: "char(1)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1) CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "nivelEstudio_Id",
                table: "formacion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_formacion",
                table: "formacion",
                column: "formacionId");

            migrationBuilder.CreateTable(
                name: "idioma",
                columns: table => new
                {
                    idiomaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idiomaNombre = table.Column<string>(type: "nvarchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_idioma", x => x.idiomaId);
                });

            migrationBuilder.CreateTable(
                name: "nivelEstudio",
                columns: table => new
                {
                    nivelEstudioId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nivelEstudioNombre = table.Column<string>(type: "nvarchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nivelEstudio", x => x.nivelEstudioId);
                });

            migrationBuilder.CreateTable(
                name: "usuarioIdioma",
                columns: table => new
                {
                    usuarioIdiomaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    usuarioIdiomaNivel = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    usuario_Id = table.Column<int>(nullable: false),
                    idioma_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarioIdioma", x => x.usuarioIdiomaId);
                    table.ForeignKey(
                        name: "FK_usuarioIdioma_idioma_idioma_Id",
                        column: x => x.idioma_Id,
                        principalTable: "idioma",
                        principalColumn: "idiomaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_usuarioIdioma_usuario_usuario_Id",
                        column: x => x.usuario_Id,
                        principalTable: "usuario",
                        principalColumn: "usuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_formacion_nivelEstudio_Id",
                table: "formacion",
                column: "nivelEstudio_Id");

            migrationBuilder.CreateIndex(
                name: "IX_formacion_usuario_Id",
                table: "formacion",
                column: "usuario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_usuarioIdioma_idioma_Id",
                table: "usuarioIdioma",
                column: "idioma_Id");

            migrationBuilder.CreateIndex(
                name: "IX_usuarioIdioma_usuario_Id",
                table: "usuarioIdioma",
                column: "usuario_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_formacion_nivelEstudio_nivelEstudio_Id",
                table: "formacion",
                column: "nivelEstudio_Id",
                principalTable: "nivelEstudio",
                principalColumn: "nivelEstudioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_formacion_usuario_usuario_Id",
                table: "formacion",
                column: "usuario_Id",
                principalTable: "usuario",
                principalColumn: "usuarioId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_formacion_nivelEstudio_nivelEstudio_Id",
                table: "formacion");

            migrationBuilder.DropForeignKey(
                name: "FK_formacion_usuario_usuario_Id",
                table: "formacion");

            migrationBuilder.DropTable(
                name: "nivelEstudio");

            migrationBuilder.DropTable(
                name: "usuarioIdioma");

            migrationBuilder.DropTable(
                name: "idioma");

            migrationBuilder.DropPrimaryKey(
                name: "PK_formacion",
                table: "formacion");

            migrationBuilder.DropIndex(
                name: "IX_formacion_nivelEstudio_Id",
                table: "formacion");

            migrationBuilder.DropIndex(
                name: "IX_formacion_usuario_Id",
                table: "formacion");

            migrationBuilder.DropColumn(
                name: "nivelEstudio_Id",
                table: "formacion");

            migrationBuilder.RenameTable(
                name: "formacion",
                newName: "Formacion");

            migrationBuilder.AlterColumn<DateTime>(
                name: "usuarioTimestamp",
                table: "usuario",
                type: "timestamp(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldRowVersion: true,
                oldNullable: true)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<string>(
                name: "formacionSatisfaccionprendizaje",
                table: "Formacion",
                type: "varchar(1) CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "formacionRecomendacion",
                table: "Formacion",
                type: "varchar(1) CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(1)");

            migrationBuilder.AlterColumn<string>(
                name: "formacionNivelProfesorado",
                table: "Formacion",
                type: "varchar(1) CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "formacionFechaInicio",
                table: "Formacion",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "formacionFechaFinal",
                table: "Formacion",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "formacionEstado",
                table: "Formacion",
                type: "varchar(1) CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(1)");

            migrationBuilder.AlterColumn<string>(
                name: "formacionCentroEducativo",
                table: "Formacion",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)");

            migrationBuilder.AlterColumn<string>(
                name: "formacionAreaDeEstudio",
                table: "Formacion",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)");

            migrationBuilder.AlterColumn<string>(
                name: "formacionAccesoAEmpleo",
                table: "Formacion",
                type: "varchar(1) CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(1)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "areaEstudioId",
                table: "Formacion",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "areaEstudio_Id",
                table: "Formacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "usuarioId",
                table: "Formacion",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Formacion",
                table: "Formacion",
                column: "formacionId");

            migrationBuilder.CreateTable(
                name: "AreaEstudio",
                columns: table => new
                {
                    areaEstudioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    areaEstudioNombre = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaEstudio", x => x.areaEstudioId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Formacion_areaEstudioId",
                table: "Formacion",
                column: "areaEstudioId");

            migrationBuilder.CreateIndex(
                name: "IX_Formacion_usuarioId",
                table: "Formacion",
                column: "usuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Formacion_AreaEstudio_areaEstudioId",
                table: "Formacion",
                column: "areaEstudioId",
                principalTable: "AreaEstudio",
                principalColumn: "areaEstudioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Formacion_usuario_usuarioId",
                table: "Formacion",
                column: "usuarioId",
                principalTable: "usuario",
                principalColumn: "usuarioId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

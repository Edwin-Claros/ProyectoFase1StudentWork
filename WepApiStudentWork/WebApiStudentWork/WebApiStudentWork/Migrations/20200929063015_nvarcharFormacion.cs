using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiStudentWork.Migrations
{
    public partial class nvarcharFormacion : Migration
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

            migrationBuilder.AlterColumn<string>(
                name: "formacionSatisfaccionprendizaje",
                table: "formacion",
                type: "nvarchar(5)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "formacionRecomendacion",
                table: "formacion",
                type: "nvarchar(5)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(1)");

            migrationBuilder.AlterColumn<string>(
                name: "formacionNivelProfesorado",
                table: "formacion",
                type: "nvarchar(5)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "formacionAccesoAEmpleo",
                table: "formacion",
                type: "nvarchar(5)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(1)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                table: "formacion",
                type: "char(1)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "formacionRecomendacion",
                table: "formacion",
                type: "char(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)");

            migrationBuilder.AlterColumn<string>(
                name: "formacionNivelProfesorado",
                table: "formacion",
                type: "char(1)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "formacionAccesoAEmpleo",
                table: "formacion",
                type: "char(1)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldNullable: true);
        }
    }
}

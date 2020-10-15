using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiStudentWork.Migrations
{
    public partial class deleteTypeImagen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "usuarioImagenType",
                table: "usuarioImagen");

            migrationBuilder.AlterColumn<DateTime>(
                name: "usuarioTimestamp",
                table: "usuario",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp(6)",
                oldNullable: true)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "usuarioImagenType",
                table: "usuarioImagen",
                type: "nvarchar(150)",
                nullable: true);

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

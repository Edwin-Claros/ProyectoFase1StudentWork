using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiStudentWork.Migrations
{
    public partial class ModeloEmpresaSector : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "empresaSector_Id",
                table: "experiencia",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "empresaSector",
                columns: table => new
                {
                    empresaSectorId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    empresaSectorNombre = table.Column<string>(type: "nvarchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empresaSector", x => x.empresaSectorId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_experiencia_empresaSector_Id",
                table: "experiencia",
                column: "empresaSector_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_experiencia_empresaSector_empresaSector_Id",
                table: "experiencia",
                column: "empresaSector_Id",
                principalTable: "empresaSector",
                principalColumn: "empresaSectorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_experiencia_empresaSector_empresaSector_Id",
                table: "experiencia");

            migrationBuilder.DropTable(
                name: "empresaSector");

            migrationBuilder.DropIndex(
                name: "IX_experiencia_empresaSector_Id",
                table: "experiencia");

            migrationBuilder.DropColumn(
                name: "empresaSector_Id",
                table: "experiencia");

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

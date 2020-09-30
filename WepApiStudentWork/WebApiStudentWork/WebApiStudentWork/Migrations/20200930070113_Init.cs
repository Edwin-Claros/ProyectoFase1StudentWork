using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiStudentWork.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "situacionActual",
                columns: table => new
                {
                    situacionActualId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    situacionActualNombre = table.Column<string>(type: "nvarchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_situacionActual", x => x.situacionActualId);
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
                    usuarioApellido = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    usuarioCorreo = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    usuarioDNI = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    usuarioTelefono = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    usuarioSkype = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    usuarioDireccion = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    usuarioCodigoPostal = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    usuarioDescripcion = table.Column<string>(type: "nvarchar(300)", nullable: true),
                    usuarioFacebook = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    usuarioInstagram = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    usuarioTwitter = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    usuarioEstadoCivil = table.Column<string>(type: "char(1)", nullable: false),
                    usuarioVehiculoPropio = table.Column<string>(type: "char(1)", nullable: false),
                    usuarioGenero = table.Column<string>(type: "char(1)", nullable: false),
                    usuarioFechaNacimiento = table.Column<DateTime>(type: "date", nullable: false),
                    usuarioTimestamp = table.Column<DateTime>(rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    pais_Id = table.Column<int>(nullable: false),
                    paisDepartamento_Id = table.Column<int>(nullable: true),
                    paisCiudad_Id = table.Column<int>(nullable: true),
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

            migrationBuilder.CreateTable(
                name: "conocimiento",
                columns: table => new
                {
                    conocimientoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    conocimientoNombre = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    usuario_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conocimiento", x => x.conocimientoId);
                    table.ForeignKey(
                        name: "FK_conocimiento_usuario_usuario_Id",
                        column: x => x.usuario_Id,
                        principalTable: "usuario",
                        principalColumn: "usuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "experiencia",
                columns: table => new
                {
                    experienciaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    experienciaEmpresa = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    experienciaDestacar = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    experienciaMejorar = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    experienciaCargo = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    experienciaArea = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    experienciaFuncionesYLogros = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    experienciaFechaInicio = table.Column<DateTime>(type: "date", nullable: false),
                    experienciaFechaFinal = table.Column<DateTime>(type: "date", nullable: false),
                    experienciaRecomendacion = table.Column<string>(type: "char(1)", nullable: false),
                    usuario_Id = table.Column<int>(nullable: false),
                    empresaSector_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_experiencia", x => x.experienciaId);
                    table.ForeignKey(
                        name: "FK_experiencia_empresaSector_empresaSector_Id",
                        column: x => x.empresaSector_Id,
                        principalTable: "empresaSector",
                        principalColumn: "empresaSectorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_experiencia_usuario_usuario_Id",
                        column: x => x.usuario_Id,
                        principalTable: "usuario",
                        principalColumn: "usuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "formacion",
                columns: table => new
                {
                    formacionId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    formacionCentroEducativo = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    formacionAreaDeEstudio = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    formacionNivelProfesorado = table.Column<string>(type: "nvarchar(5)", nullable: true),
                    formacionSatisfaccionprendizaje = table.Column<string>(type: "nvarchar(5)", nullable: true),
                    formacionAccesoAEmpleo = table.Column<string>(type: "nvarchar(5)", nullable: true),
                    formacionRecomendacion = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    formacionEstado = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    formacionFechaInicio = table.Column<DateTime>(type: "date", nullable: false),
                    formacionFechaFinal = table.Column<DateTime>(type: "date", nullable: false),
                    usuario_Id = table.Column<int>(nullable: false),
                    nivelEstudio_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_formacion", x => x.formacionId);
                    table.ForeignKey(
                        name: "FK_formacion_nivelEstudio_nivelEstudio_Id",
                        column: x => x.nivelEstudio_Id,
                        principalTable: "nivelEstudio",
                        principalColumn: "nivelEstudioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_formacion_usuario_usuario_Id",
                        column: x => x.usuario_Id,
                        principalTable: "usuario",
                        principalColumn: "usuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "preferenciasDeTrabajo",
                columns: table => new
                {
                    preferenciasDeTrabajoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    preferenciasDeTrabajoPuesto = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    preferenciasDeTrabajoSalario = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    preferenciasDeTrabajoArea = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    preferenciasDeTrabajoViajar = table.Column<string>(type: "char(1)", nullable: false),
                    preferenciasDeTrabajoResidencia = table.Column<string>(type: "char(1)", nullable: false),
                    usuario_Id = table.Column<int>(nullable: false),
                    paisDepartamento_Id = table.Column<int>(nullable: false),
                    situacionActual_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_preferenciasDeTrabajo", x => x.preferenciasDeTrabajoId);
                    table.ForeignKey(
                        name: "FK_preferenciasDeTrabajo_paisDepartamento_paisDepartamento_Id",
                        column: x => x.paisDepartamento_Id,
                        principalTable: "paisDepartamento",
                        principalColumn: "paisDepartamentoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_preferenciasDeTrabajo_situacionActual_situacionActual_Id",
                        column: x => x.situacionActual_Id,
                        principalTable: "situacionActual",
                        principalColumn: "situacionActualId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_preferenciasDeTrabajo_usuario_usuario_Id",
                        column: x => x.usuario_Id,
                        principalTable: "usuario",
                        principalColumn: "usuarioId",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "usuarioImagen",
                columns: table => new
                {
                    usuarioImagenId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    usuarioImagenImagen = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    usuarioImagenType = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    usuario_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarioImagen", x => x.usuarioImagenId);
                    table.ForeignKey(
                        name: "FK_usuarioImagen_usuario_usuario_Id",
                        column: x => x.usuario_Id,
                        principalTable: "usuario",
                        principalColumn: "usuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_conocimiento_usuario_Id",
                table: "conocimiento",
                column: "usuario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_experiencia_empresaSector_Id",
                table: "experiencia",
                column: "empresaSector_Id");

            migrationBuilder.CreateIndex(
                name: "IX_experiencia_usuario_Id",
                table: "experiencia",
                column: "usuario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_formacion_nivelEstudio_Id",
                table: "formacion",
                column: "nivelEstudio_Id");

            migrationBuilder.CreateIndex(
                name: "IX_formacion_usuario_Id",
                table: "formacion",
                column: "usuario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_paisCiudad_paisDepartamento_Id",
                table: "paisCiudad",
                column: "paisDepartamento_Id");

            migrationBuilder.CreateIndex(
                name: "IX_paisDepartamento_pais_Id",
                table: "paisDepartamento",
                column: "pais_Id");

            migrationBuilder.CreateIndex(
                name: "IX_preferenciasDeTrabajo_paisDepartamento_Id",
                table: "preferenciasDeTrabajo",
                column: "paisDepartamento_Id");

            migrationBuilder.CreateIndex(
                name: "IX_preferenciasDeTrabajo_situacionActual_Id",
                table: "preferenciasDeTrabajo",
                column: "situacionActual_Id");

            migrationBuilder.CreateIndex(
                name: "IX_preferenciasDeTrabajo_usuario_Id",
                table: "preferenciasDeTrabajo",
                column: "usuario_Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_usuarioIdioma_idioma_Id",
                table: "usuarioIdioma",
                column: "idioma_Id");

            migrationBuilder.CreateIndex(
                name: "IX_usuarioIdioma_usuario_Id",
                table: "usuarioIdioma",
                column: "usuario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_usuarioImagen_usuario_Id",
                table: "usuarioImagen",
                column: "usuario_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "conocimiento");

            migrationBuilder.DropTable(
                name: "experiencia");

            migrationBuilder.DropTable(
                name: "formacion");

            migrationBuilder.DropTable(
                name: "preferenciasDeTrabajo");

            migrationBuilder.DropTable(
                name: "usuarioIdioma");

            migrationBuilder.DropTable(
                name: "usuarioImagen");

            migrationBuilder.DropTable(
                name: "empresaSector");

            migrationBuilder.DropTable(
                name: "nivelEstudio");

            migrationBuilder.DropTable(
                name: "situacionActual");

            migrationBuilder.DropTable(
                name: "idioma");

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

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiStudentWork.DataContext;

namespace WebApiStudentWork.Migrations
{
    [DbContext(typeof(StudentWorkContext))]
    partial class StudentWorkContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebApiStudentWork.Models.EmpresaSector", b =>
                {
                    b.Property<int>("empresaSectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("empresaSectorNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("empresaSectorId");

                    b.ToTable("empresaSector");
                });

            modelBuilder.Entity("WebApiStudentWork.Models.Experiencia", b =>
                {
                    b.Property<int>("experienciaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("empresaSector_Id")
                        .HasColumnType("int");

                    b.Property<string>("experienciaArea")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("experienciaCargo")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("experienciaDestacar")
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("experienciaEmpresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("experienciaFechaFinal")
                        .HasColumnType("date");

                    b.Property<DateTime>("experienciaFechaInicio")
                        .HasColumnType("date");

                    b.Property<string>("experienciaFuncionesYLogros")
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("experienciaMejorar")
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("experienciaRecomendacion")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.Property<int>("usuario_Id")
                        .HasColumnType("int");

                    b.HasKey("experienciaId");

                    b.HasIndex("empresaSector_Id");

                    b.HasIndex("usuario_Id");

                    b.ToTable("experiencia");
                });

            modelBuilder.Entity("WebApiStudentWork.Models.Formacion", b =>
                {
                    b.Property<int>("formacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("formacionAccesoAEmpleo")
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("formacionAreaDeEstudio")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("formacionCentroEducativo")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("formacionEstado")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("formacionFechaFinal")
                        .HasColumnType("date");

                    b.Property<DateTime>("formacionFechaInicio")
                        .HasColumnType("date");

                    b.Property<string>("formacionNivelProfesorado")
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("formacionRecomendacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("formacionSatisfaccionprendizaje")
                        .HasColumnType("nvarchar(5)");

                    b.Property<int>("nivelEstudio_Id")
                        .HasColumnType("int");

                    b.Property<int>("usuario_Id")
                        .HasColumnType("int");

                    b.HasKey("formacionId");

                    b.HasIndex("nivelEstudio_Id");

                    b.HasIndex("usuario_Id");

                    b.ToTable("formacion");
                });

            modelBuilder.Entity("WebApiStudentWork.Models.Idioma", b =>
                {
                    b.Property<int>("idiomaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("idiomaNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("idiomaId");

                    b.ToTable("idioma");
                });

            modelBuilder.Entity("WebApiStudentWork.Models.LicenciaConducir", b =>
                {
                    b.Property<int>("licenciaConducirId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("licenciaConducirNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("licenciaConducirId");

                    b.ToTable("licenciaConducir");
                });

            modelBuilder.Entity("WebApiStudentWork.Models.NivelEstudio", b =>
                {
                    b.Property<int>("nivelEstudioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nivelEstudioNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("nivelEstudioId");

                    b.ToTable("nivelEstudio");
                });

            modelBuilder.Entity("WebApiStudentWork.Models.Pais", b =>
                {
                    b.Property<int>("paisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("paisNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("paisId");

                    b.ToTable("pais");
                });

            modelBuilder.Entity("WebApiStudentWork.Models.PaisCiudad", b =>
                {
                    b.Property<int>("paisCiudadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("paisCiudadNombre")
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("paisDepartamento_Id")
                        .HasColumnType("int");

                    b.HasKey("paisCiudadId");

                    b.HasIndex("paisDepartamento_Id");

                    b.ToTable("paisCiudad");
                });

            modelBuilder.Entity("WebApiStudentWork.Models.PaisDepartamento", b =>
                {
                    b.Property<int>("paisDepartamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("paisDepartamentoNombre")
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("pais_Id")
                        .HasColumnType("int");

                    b.HasKey("paisDepartamentoId");

                    b.HasIndex("pais_Id");

                    b.ToTable("paisDepartamento");
                });

            modelBuilder.Entity("WebApiStudentWork.Models.Usuario", b =>
                {
                    b.Property<int>("usuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("licenciaConducir_Id")
                        .HasColumnType("int");

                    b.Property<int?>("paisCiudad_Id")
                        .HasColumnType("int");

                    b.Property<int?>("paisDepartamento_Id")
                        .HasColumnType("int");

                    b.Property<int>("pais_Id")
                        .HasColumnType("int");

                    b.Property<string>("usuarioApellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("usuarioCodigoPostal")
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("usuarioCorreo")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("usuarioDNI")
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("usuarioDescripcion")
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("usuarioDireccion")
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("usuarioEstadoCivil")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.Property<string>("usuarioFacebook")
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("usuarioFechaNacimiento")
                        .HasColumnType("date");

                    b.Property<string>("usuarioGenero")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.Property<string>("usuarioInstagram")
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("usuarioNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("usuarioSkype")
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("usuarioTelefono")
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime?>("usuarioTimestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp(6)");

                    b.Property<string>("usuarioTwitter")
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("usuarioVehiculoPropio")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.HasKey("usuarioId");

                    b.HasIndex("licenciaConducir_Id");

                    b.HasIndex("paisCiudad_Id");

                    b.HasIndex("paisDepartamento_Id");

                    b.HasIndex("pais_Id");

                    b.ToTable("usuario");
                });

            modelBuilder.Entity("WebApiStudentWork.Models.UsuarioIdioma", b =>
                {
                    b.Property<int>("usuarioIdiomaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("idioma_Id")
                        .HasColumnType("int");

                    b.Property<string>("usuarioIdiomaNivel")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("usuario_Id")
                        .HasColumnType("int");

                    b.HasKey("usuarioIdiomaId");

                    b.HasIndex("idioma_Id");

                    b.HasIndex("usuario_Id");

                    b.ToTable("usuarioIdioma");
                });

            modelBuilder.Entity("WebApiStudentWork.Models.Experiencia", b =>
                {
                    b.HasOne("WebApiStudentWork.Models.EmpresaSector", "EmpresaSector")
                        .WithMany("Experiencias")
                        .HasForeignKey("empresaSector_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebApiStudentWork.Models.Usuario", "Usuario")
                        .WithMany("Experiencias")
                        .HasForeignKey("usuario_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApiStudentWork.Models.Formacion", b =>
                {
                    b.HasOne("WebApiStudentWork.Models.NivelEstudio", "NivelEstudio")
                        .WithMany("Formaciones")
                        .HasForeignKey("nivelEstudio_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebApiStudentWork.Models.Usuario", "Usuario")
                        .WithMany("Formaciones")
                        .HasForeignKey("usuario_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApiStudentWork.Models.PaisCiudad", b =>
                {
                    b.HasOne("WebApiStudentWork.Models.PaisDepartamento", "PaisDepartamento")
                        .WithMany("PaisCiudades")
                        .HasForeignKey("paisDepartamento_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApiStudentWork.Models.PaisDepartamento", b =>
                {
                    b.HasOne("WebApiStudentWork.Models.Pais", "Pais")
                        .WithMany("PaisDepartamentos")
                        .HasForeignKey("pais_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApiStudentWork.Models.Usuario", b =>
                {
                    b.HasOne("WebApiStudentWork.Models.LicenciaConducir", "LicenciaConducir")
                        .WithMany("Usuarios")
                        .HasForeignKey("licenciaConducir_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebApiStudentWork.Models.PaisCiudad", "PaisCiudad")
                        .WithMany("Usuarios")
                        .HasForeignKey("paisCiudad_Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WebApiStudentWork.Models.PaisDepartamento", "PaisDepartamento")
                        .WithMany("Usuarios")
                        .HasForeignKey("paisDepartamento_Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WebApiStudentWork.Models.Pais", "Pais")
                        .WithMany("Usuarios")
                        .HasForeignKey("pais_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApiStudentWork.Models.UsuarioIdioma", b =>
                {
                    b.HasOne("WebApiStudentWork.Models.Idioma", "Idioma")
                        .WithMany("UsuarioIdiomas")
                        .HasForeignKey("idioma_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebApiStudentWork.Models.Usuario", "Usuario")
                        .WithMany("UsuarioIdiomas")
                        .HasForeignKey("usuario_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiStudentWork.DataContext;

namespace WebApiStudentWork.Migrations
{
    [DbContext(typeof(StudentWorkContext))]
    [Migration("20200808233040_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebApiStudentWork.Models.Usuario", b =>
                {
                    b.Property<int>("usuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("usuarioCorreo")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("usuarioNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime?>("usuarioTimestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp(6)");

                    b.HasKey("usuarioId");

                    b.ToTable("usuario");
                });
#pragma warning restore 612, 618
        }
    }
}

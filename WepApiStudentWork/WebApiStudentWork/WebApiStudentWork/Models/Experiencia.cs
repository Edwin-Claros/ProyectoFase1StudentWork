using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiStudentWork.Models
{
    public class Experiencia
    {
        public int experienciaId { get; set; }
        public string experienciaEmpresa { get; set; }
        public string experienciaDestacar { get; set; }
        public string experienciaMejorar { get; set; }
        public string experienciaSector { get; set; }//Hacer Dropdown
        public string experienciaCargo { get; set; }
        public string experienciaArea { get; set; }//HacerDropdown
        public string experienciaFuncionesYLogros { get; set; }
        public DateTime experienciaFechaInicio { get; set; }
        public DateTime experienciaFechaFinal { get; set; } // nullable
        public char experienciaRecomendacion { get; set; }

        public int usuario_Id { get; set; }
        public int empresaSector_Id { get; set; }


        public Usuario Usuario { get; set; }
        public EmpresaSector EmpresaSector { get; set; }

    }
    public class ExperienciaMap : IEntityTypeConfiguration<Experiencia>
    {
        public void Configure(EntityTypeBuilder<Experiencia> builder)
        {
            builder.ToTable("experiencia");
            builder.HasKey(q => q.experienciaId);
            builder.Property(e => e.experienciaId).IsRequired().UseMySqlIdentityColumn();
            builder.Property(e => e.experienciaEmpresa).HasColumnType("nvarchar(150)").IsRequired();
            builder.Property(e => e.experienciaDestacar).HasColumnType("nvarchar(150)");
            builder.Property(e => e.experienciaMejorar).HasColumnType("nvarchar(150)");
            builder.Property(e => e.experienciaSector).HasColumnType("nvarchar(150)").IsRequired();
            builder.Property(e => e.experienciaCargo).HasColumnType("nvarchar(150)").IsRequired();
            builder.Property(e => e.experienciaArea).HasColumnType("nvarchar(150)").IsRequired();
            builder.Property(e => e.experienciaFuncionesYLogros).HasColumnType("nvarchar(150)");
            builder.Property(e => e.experienciaFechaInicio).HasColumnType("date").IsRequired();
            builder.Property(e => e.experienciaFechaFinal).HasColumnType("date").IsRequired();
            builder.Property(e => e.experienciaRecomendacion).HasColumnType("char(1)");

            builder.HasOne(e => e.Usuario).WithMany(e => e.Experiencias).HasForeignKey(e => e.usuario_Id).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.EmpresaSector).WithMany(e => e.Experiencias).HasForeignKey(e => e.empresaSector_Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

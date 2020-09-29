using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiStudentWork.Models
{
    public class Formacion
    {
        public int formacionId { get; set; }
        public string formacionCentroEducativo { get; set; }
        public string formacionAreaDeEstudio { get; set; }
        public char? formacionNivelProfesorado { get; set; }
        public char? formacionSatisfaccionprendizaje { get; set; }
        public char? formacionAccesoAEmpleo { get; set; }
        public char formacionRecomendacion { get; set; }
        public string formacionEstado { get; set; }
        public DateTime formacionFechaInicio { get; set; }
        public DateTime formacionFechaFinal { get; set; }

        public int usuario_Id { get; set; }
        public int nivelEstudio_Id { get; set; }

        public Usuario Usuario { get; set; }
        public NivelEstudio NivelEstudio { get; set; }
    }
    public class FormacionMap : IEntityTypeConfiguration<Formacion>
    {
        public void Configure(EntityTypeBuilder<Formacion> builder)
        {
            builder.ToTable("formacion");
            builder.HasKey(q => q.formacionId);
            builder.Property(e => e.formacionId).IsRequired().UseMySqlIdentityColumn();
            builder.Property(e => e.formacionCentroEducativo).HasColumnType("nvarchar(150)").IsRequired();
            builder.Property(e => e.formacionAreaDeEstudio).HasColumnType("nvarchar(150)").IsRequired();
            builder.Property(e => e.formacionNivelProfesorado).HasColumnType("nvarchar(5)");
            builder.Property(e => e.formacionSatisfaccionprendizaje).HasColumnType("nvarchar(5)");
            builder.Property(e => e.formacionAccesoAEmpleo).HasColumnType("nvarchar(5)");
            builder.Property(e => e.formacionRecomendacion).HasColumnType("nvarchar(5)").IsRequired();
            builder.Property(e => e.formacionEstado).HasColumnType("nvarchar(150)").IsRequired();
            builder.Property(e => e.formacionFechaInicio).HasColumnType("date").IsRequired();
            builder.Property(e => e.formacionFechaFinal).HasColumnType("date").IsRequired();

            builder.HasOne(e => e.Usuario).WithMany(e => e.Formaciones).HasForeignKey(e => e.usuario_Id).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.NivelEstudio).WithMany(e => e.Formaciones).HasForeignKey(e => e.nivelEstudio_Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

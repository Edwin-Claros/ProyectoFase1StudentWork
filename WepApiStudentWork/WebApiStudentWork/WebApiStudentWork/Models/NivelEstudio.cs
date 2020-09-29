using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiStudentWork.Models
{
    public class NivelEstudio
    {
        public int nivelEstudioId { get; set; }
        public string nivelEstudioNombre { get; set; }

        public List<Formacion> Formaciones { get; set; }
    }
    public class NivelEstudioMap : IEntityTypeConfiguration<NivelEstudio>
    {
        public void Configure(EntityTypeBuilder<NivelEstudio> builder)
        {
            builder.ToTable("nivelEstudio");
            builder.HasKey(q => q.nivelEstudioId);
            builder.Property(e => e.nivelEstudioId).IsRequired().UseMySqlIdentityColumn();
            builder.Property(e => e.nivelEstudioNombre).HasColumnType("nvarchar(150)").IsRequired();

        }
    }
}

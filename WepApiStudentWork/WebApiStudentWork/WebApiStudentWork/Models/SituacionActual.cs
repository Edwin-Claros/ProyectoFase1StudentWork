using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiStudentWork.Models
{
    public class SituacionActual
    {
        public int situacionActualId { get; set; }
        public string situacionActualNombre { get; set; }

        public List<PreferenciasDeTrabajo> PreferenciasDeTrabajos { get; set; }
    }
    public class SituacionActualMap : IEntityTypeConfiguration<SituacionActual>
    {
        public void Configure(EntityTypeBuilder<SituacionActual> builder)
        {
            builder.ToTable("situacionActual");
            builder.HasKey(q => q.situacionActualId);
            builder.Property(e => e.situacionActualId).IsRequired().UseMySqlIdentityColumn();
            builder.Property(e => e.situacionActualNombre).HasColumnType("nvarchar(150)");
        }
    }
}

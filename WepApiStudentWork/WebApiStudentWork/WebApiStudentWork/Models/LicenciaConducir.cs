using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiStudentWork.Models
{
    public class LicenciaConducir
    {
        public int licenciaConducirId { get; set; }
        public string licenciaConducirNombre { get; set; }

        public List<Usuario> Usuarios { get; set; }
    }
    public class LicenciaConducirMap : IEntityTypeConfiguration<LicenciaConducir>
    {
        public void Configure(EntityTypeBuilder<LicenciaConducir> builder)
        {
            builder.ToTable("licenciaConducir");
            builder.HasKey(q => q.licenciaConducirId);
            builder.Property(e => e.licenciaConducirId).IsRequired().UseMySqlIdentityColumn();
            builder.Property(e => e.licenciaConducirNombre).HasColumnType("nvarchar(150)").IsRequired();
        }
    }
}

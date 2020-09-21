using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiStudentWork.Models
{
    public class EmpresaSector
    {
        public int empresaSectorId { get; set; }
        public string empresaSectorNombre { get; set; }

        public List<Experiencia> Experiencias { get; set; }
    }
    public class EmpresaSectorMap : IEntityTypeConfiguration<EmpresaSector>
    {
        public void Configure(EntityTypeBuilder<EmpresaSector> builder)
        {
            builder.ToTable("empresaSector");
            builder.HasKey(q => q.empresaSectorId);
            builder.Property(e => e.empresaSectorId).IsRequired().UseMySqlIdentityColumn();
            builder.Property(e => e.empresaSectorNombre).HasColumnType("nvarchar(150)").IsRequired();

        }
    }
}

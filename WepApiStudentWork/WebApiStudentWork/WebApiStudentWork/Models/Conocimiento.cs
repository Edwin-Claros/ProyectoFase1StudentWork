using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiStudentWork.Models
{
    public class Conocimiento
    {
        public int conocimientoId { get; set; }
        public string conocimientoNombre { get; set; }

        public int usuario_Id { get; set; }

        public Usuario Usuario { get; set; }
    }
    public class ConocimientoMap : IEntityTypeConfiguration<Conocimiento>
    {
        public void Configure(EntityTypeBuilder<Conocimiento> builder)
        {
            builder.ToTable("conocimiento");
            builder.HasKey(q => q.conocimientoId);
            builder.Property(e => e.conocimientoId).IsRequired().UseMySqlIdentityColumn();
            builder.Property(e => e.conocimientoNombre).HasColumnType("nvarchar(150)").IsRequired();

            builder.HasOne(e => e.Usuario).WithMany(e => e.Conocimientos).HasForeignKey(e => e.usuario_Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiStudentWork.Models
{
    public class Pais
    {
        public int paisId { get; set; }
        public string paisNombre { get; set; }



        public List<Usuario> Usuarios { get; set; }
        public List<PaisDepartamento> PaisDepartamentos { get; set; }
    }
    public class PaisMap : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.ToTable("pais");
            builder.HasKey(q => q.paisId);
            builder.Property(e => e.paisId).IsRequired().UseMySqlIdentityColumn();
            builder.Property(e => e.paisNombre).HasColumnType("nvarchar(150)").IsRequired();

        }
    }
}

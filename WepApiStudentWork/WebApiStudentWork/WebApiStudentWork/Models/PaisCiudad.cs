using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiStudentWork.Models
{
    public class PaisCiudad
    {
        public int paisCiudadId { get; set; }
        public string paisCiudadNombre { get; set; }

        public int paisDepartamento_Id { get; set; }


        public PaisDepartamento PaisDepartamento { get; set; }


        public List<Usuario> Usuarios { get; set; }
    }
    public class PaisCiudadMap : IEntityTypeConfiguration<PaisCiudad>
    {
        public void Configure(EntityTypeBuilder<PaisCiudad> builder)
        {
            builder.ToTable("paisCiudad");
            builder.HasKey(q => q.paisCiudadId);
            builder.Property(e => e.paisCiudadId).IsRequired().UseMySqlIdentityColumn();
            builder.Property(e => e.paisCiudadNombre).HasColumnType("nvarchar(150)");

            builder.HasOne(e => e.PaisDepartamento).WithMany(e => e.PaisCiudades).HasForeignKey(e => e.paisDepartamento_Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

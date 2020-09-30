using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiStudentWork.Models
{
    public class PaisDepartamento
    {
        public int paisDepartamentoId { get; set; }
        public string paisDepartamentoNombre { get; set; }


        public int pais_Id { get; set; }


        public Pais Pais { get; set; }


        public List<Usuario> Usuarios { get; set; }
        public List<PaisCiudad> PaisCiudades { get; set; }
        public List<PreferenciasDeTrabajo> PreferenciasDeTrabajos { get; set; }
    }
    public class PaisDepartamentoMap : IEntityTypeConfiguration<PaisDepartamento>
    {
        public void Configure(EntityTypeBuilder<PaisDepartamento> builder)
        {
            builder.ToTable("paisDepartamento");
            builder.HasKey(q => q.paisDepartamentoId);
            builder.Property(e => e.paisDepartamentoId).IsRequired().UseMySqlIdentityColumn();
            builder.Property(e => e.paisDepartamentoNombre).HasColumnType("nvarchar(150)");

            builder.HasOne(e => e.Pais).WithMany(e => e.PaisDepartamentos).HasForeignKey(e => e.pais_Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

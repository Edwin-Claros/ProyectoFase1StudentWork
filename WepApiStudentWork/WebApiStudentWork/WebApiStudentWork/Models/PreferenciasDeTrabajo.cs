using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiStudentWork.Models
{
    public class PreferenciasDeTrabajo
    {
        public int preferenciasDeTrabajoId { get; set; }
        public string preferenciasDeTrabajoPuesto { get; set; }
        public string preferenciasDeTrabajoSalario { get; set; }
        public string preferenciasDeTrabajoArea { get; set; }
        public char preferenciasDeTrabajoViajar { get; set; }
        public char preferenciasDeTrabajoResidencia { get; set; }

        public int usuario_Id { get; set; }
        public int paisDepartamento_Id { get; set; }
        public int situacionActual_Id { get; set; }

        public Usuario Usuario { get; set; }
        public PaisDepartamento PaisDepartamento { get; set; }
        public SituacionActual SituacionActual { get; set; }
    }
    public class PreferenciasDeTrabajoMap : IEntityTypeConfiguration<PreferenciasDeTrabajo>
    {
        public void Configure(EntityTypeBuilder<PreferenciasDeTrabajo> builder)
        {
            builder.ToTable("preferenciasDeTrabajo");
            builder.HasKey(q => q.preferenciasDeTrabajoId);
            builder.Property(e => e.preferenciasDeTrabajoId).IsRequired().UseMySqlIdentityColumn();
            builder.Property(e => e.preferenciasDeTrabajoPuesto).HasColumnType("nvarchar(150)");
            builder.Property(e => e.preferenciasDeTrabajoSalario).HasColumnType("nvarchar(150)");
            builder.Property(e => e.preferenciasDeTrabajoArea).HasColumnType("nvarchar(150)");
            builder.Property(e => e.preferenciasDeTrabajoViajar).HasColumnType("char(1)");
            builder.Property(e => e.preferenciasDeTrabajoResidencia).HasColumnType("char(1)");

            builder.HasOne(e => e.Usuario).WithMany(e => e.PreferenciasDeTrabajos).HasForeignKey(e => e.usuario_Id).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.PaisDepartamento).WithMany(e => e.PreferenciasDeTrabajos).HasForeignKey(e => e.paisDepartamento_Id).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.SituacionActual).WithMany(e => e.PreferenciasDeTrabajos).HasForeignKey(e => e.situacionActual_Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiStudentWork.Models
{
    public class UsuarioIdioma
    {
        public int usuarioIdiomaId { get; set; }
        public string usuarioIdiomaNivel { get; set; }

        public int usuario_Id { get; set; }
        public int idioma_Id { get; set; }

        public Usuario Usuario { get; set; }
        public Idioma Idioma { get; set; }
    }
        public class UsuarioIdiomaMap : IEntityTypeConfiguration<UsuarioIdioma>
    {
        public void Configure(EntityTypeBuilder<UsuarioIdioma> builder)
        {
            builder.ToTable("usuarioIdioma");
            builder.HasKey(q => q.usuarioIdiomaId);
            builder.Property(e => e.usuarioIdiomaId).IsRequired().UseMySqlIdentityColumn();
            builder.Property(e => e.usuarioIdiomaNivel).HasColumnType("nvarchar(150)").IsRequired();

            builder.HasOne(e => e.Usuario).WithMany(e => e.UsuarioIdiomas).HasForeignKey(e => e.usuario_Id).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Idioma).WithMany(e => e.UsuarioIdiomas).HasForeignKey(e => e.idioma_Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

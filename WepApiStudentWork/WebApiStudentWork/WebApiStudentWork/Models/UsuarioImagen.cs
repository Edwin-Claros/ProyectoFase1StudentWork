using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiStudentWork.Models
{
    public class UsuarioImagen
    {
        public int usuarioImagenId { get; set; }
        public byte[] usuarioImagenImagen { get; set; }

        public int usuario_Id { get; set; }

        public Usuario Usuario { get; set; }
    }
    public class UsuarioImagenMap : IEntityTypeConfiguration<UsuarioImagen>
    {
        public void Configure(EntityTypeBuilder<UsuarioImagen> builder)
        {
            builder.ToTable("usuarioImagen");
            builder.HasKey(q => q.usuarioImagenId);
            builder.Property(e => e.usuarioImagenId).IsRequired().UseMySqlIdentityColumn();

            builder.HasOne(e => e.Usuario).WithMany(e => e.UserImagenes).HasForeignKey(e => e.usuario_Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

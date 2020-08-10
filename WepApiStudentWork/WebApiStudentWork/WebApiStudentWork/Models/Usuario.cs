using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiStudentWork.Models
{
    public class Usuario
    {
        public int usuarioId { get; set; }
        public string usuarioNombre { get; set; }
        public string usuarioCorreo { get; set; }
        public string usuarioContraseña { get; set; }
        [Timestamp]
        public byte[] usuarioTimestamp { get; set; }
    }

    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario");
            builder.HasKey(q => q.usuarioId);
            builder.Property(e => e.usuarioId).IsRequired().UseMySqlIdentityColumn();
            builder.Property(e => e.usuarioNombre).HasColumnType("nvarchar(150)").IsRequired();
            builder.Property(e => e.usuarioCorreo).HasColumnType("nvarchar(150)").IsRequired();
            builder.Property(e => e.usuarioContraseña).HasColumnType("nvarchar(150)").IsRequired();

        }
    }

}

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
        public string usuarioApellido { get; set; }
        public string usuarioCorreo { get; set; }
        //public string usuarioContraseña { get; set; }
        public string usuarioDNI { get; set; }
        public string usuarioTelefono { get; set; }
        public string usuarioSkype { get; set; }
        public string usuarioDireccion { get; set; }
        public string usuarioCodigoPostal { get; set; }
        public string usuarioDescripcion { get; set; }
        public string usuarioFacebook { get; set; }
        public string usuarioInstagram { get; set; }
        public string usuarioTwitter { get; set; }
        public char usuarioEstadoCivil { get; set; }
        public char usuarioVehiculoPropio { get; set; }
        public char usuarioGenero { get; set; }
        public DateTime usuarioFechaNacimiento { get; set; }
        [Timestamp]
        public byte[] usuarioTimestamp { get; set; }



        public int pais_Id { get; set; }
        public int? paisDepartamento_Id { get; set; }
        public int? paisCiudad_Id { get; set; }
        public int licenciaConducir_Id { get; set; }


        public Pais Pais { get; set; }
        public PaisDepartamento PaisDepartamento { get; set; }
        public PaisCiudad PaisCiudad { get; set; }
        public LicenciaConducir LicenciaConducir { get; set; }

        public List<Experiencia> Experiencias { get; set; }
        public List<Formacion> Formaciones { get; set; }
        public List<UsuarioIdioma> UsuarioIdiomas { get; set; }
    }

    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario");
            builder.HasKey(q => q.usuarioId);
            builder.Property(e => e.usuarioId).IsRequired().UseMySqlIdentityColumn();
            builder.Property(e => e.usuarioNombre).HasColumnType("nvarchar(150)").IsRequired();
            builder.Property(e => e.usuarioApellido).HasColumnType("nvarchar(150)").IsRequired();
            builder.Property(e => e.usuarioCorreo).HasColumnType("nvarchar(150)").IsRequired();
           // builder.Property(e => e.usuarioContraseña).HasColumnType("nvarchar(150)").IsRequired();
            builder.Property(e => e.usuarioDNI).HasColumnType("nvarchar(150)");
            builder.Property(e => e.usuarioTelefono).HasColumnType("nvarchar(150)");
            builder.Property(e => e.usuarioSkype).HasColumnType("nvarchar(150)");
            builder.Property(e => e.usuarioDireccion).HasColumnType("nvarchar(150)");
            builder.Property(e => e.usuarioCodigoPostal).HasColumnType("nvarchar(150)");
            builder.Property(e => e.usuarioEstadoCivil).HasColumnType("char(1)");
            builder.Property(e => e.usuarioVehiculoPropio).HasColumnType("char(1)");
            builder.Property(e => e.usuarioGenero).HasColumnType("char(1)");
            builder.Property(e => e.usuarioFechaNacimiento).HasColumnType("date");
            builder.Property(e => e.usuarioDescripcion).HasColumnType("nvarchar(300)");
            builder.Property(e => e.usuarioFacebook).HasColumnType("nvarchar(150)");
            builder.Property(e => e.usuarioInstagram).HasColumnType("nvarchar(150)");
            builder.Property(e => e.usuarioTwitter).HasColumnType("nvarchar(150)");

            builder.HasOne(e => e.Pais).WithMany(e => e.Usuarios).HasForeignKey(e => e.pais_Id).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.PaisDepartamento).WithMany(e => e.Usuarios).HasForeignKey(e => e.paisDepartamento_Id).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.PaisCiudad).WithMany(e => e.Usuarios).HasForeignKey(e => e.paisCiudad_Id).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.LicenciaConducir).WithMany(e => e.Usuarios).HasForeignKey(e => e.licenciaConducir_Id).OnDelete(DeleteBehavior.Cascade);
        }
    }

}

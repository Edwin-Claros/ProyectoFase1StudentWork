using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiStudentWork.Models
{
    public class Idioma
    {
        public int idiomaId { get; set; }
        public string idiomaNombre { get; set; }

        public List<UsuarioIdioma> UsuarioIdiomas { get; set; }
    }
    public class IdiomaMap : IEntityTypeConfiguration<Idioma>
    {
        public void Configure(EntityTypeBuilder<Idioma> builder)
        {
            builder.ToTable("idioma");
            builder.HasKey(q => q.idiomaId);
            builder.Property(e => e.idiomaId).IsRequired().UseMySqlIdentityColumn();
            builder.Property(e => e.idiomaNombre).HasColumnType("nvarchar(150)").IsRequired();

        }
    }
}

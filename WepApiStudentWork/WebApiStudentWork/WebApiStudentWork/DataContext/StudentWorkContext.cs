using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiStudentWork.Models;

namespace WebApiStudentWork.DataContext
{
    public class StudentWorkContext : DbContext
    {
        public StudentWorkContext(DbContextOptions<StudentWorkContext> options) : base(options)
        {

        }


        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<LicenciaConducir> LicenciasConducir { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<PaisCiudad> PaisCiudades { get; set; }
        public DbSet<PaisDepartamento> PaisDepartamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new LicenciaConducirMap());
            modelBuilder.ApplyConfiguration(new PaisMap());
            modelBuilder.ApplyConfiguration(new PaisCiudadMap());
            modelBuilder.ApplyConfiguration(new PaisDepartamentoMap());

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }

    }
}

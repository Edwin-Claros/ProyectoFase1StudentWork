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
        public DbSet<Experiencia> Experiencias { get; set; }
        public DbSet<EmpresaSector> EmpresaSectores { get; set; }
        public DbSet<Formacion> Formaciones { get; set; }
        public DbSet<NivelEstudio> NivelEstudios { get; set; }
        public DbSet<Idioma> Idiomas { get; set; }
        public DbSet<UsuarioIdioma> UsuarioIdiomas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new LicenciaConducirMap());
            modelBuilder.ApplyConfiguration(new PaisMap());
            modelBuilder.ApplyConfiguration(new PaisCiudadMap());
            modelBuilder.ApplyConfiguration(new PaisDepartamentoMap());
            modelBuilder.ApplyConfiguration(new ExperienciaMap());
            modelBuilder.ApplyConfiguration(new EmpresaSectorMap());
            modelBuilder.ApplyConfiguration(new FormacionMap());
            modelBuilder.ApplyConfiguration(new NivelEstudioMap());
            modelBuilder.ApplyConfiguration(new IdiomaMap());
            modelBuilder.ApplyConfiguration(new UsuarioIdiomaMap());

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }

    }
}

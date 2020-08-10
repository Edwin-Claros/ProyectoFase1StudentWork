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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}

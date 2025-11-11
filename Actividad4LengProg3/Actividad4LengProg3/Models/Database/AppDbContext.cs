using Actividad4LengProg3.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Actividad4LengProg3.Models.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Estudiantes> Estudiantes { get; set; }
        public DbSet<Carreras> Carreras { get; set; }
        public DbSet<Recintos> Recintos { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using Ralfy_Genao_P2_AP1.Models;

namespace Ralfy_Genao_P2_AP1.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Ciudades> Ciudades { get; set; }
        public DbSet<Encuestas> Encuestas { get; set; }
        public DbSet<EncuestaDetalles> EncuestaDetalles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ciudades>().HasData(
                new Ciudades { CiudadesId = 1, Nombre = "Santo Domingo", Monto = 25000 },
                new Ciudades { CiudadesId = 2, Nombre = "Rio San Juan", Monto = 25000 },
                new Ciudades { CiudadesId = 3, Nombre = "Puerto Plata", Monto = 15500 }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
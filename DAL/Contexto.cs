using Microsoft.EntityFrameworkCore;
using Ralfy_Genao_P2_AP1.Models;

namespace Ralfy_Genao_P2_AP1.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
              : base(options) { }
        public DbSet<Ciudades> ciudades { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ciudades>().HasData(
                new Ciudades { CiudadId = 1, Nombre = "Santo Domingo", Monto = 25000 },
                new Ciudades { CiudadId = 2, Nombre = "Rio San Juan", Monto = 25000 },
                new Ciudades { CiudadId = 3, Nombre = "Puerto Plata ", Monto = 15500 }
            );

        }
    }
}
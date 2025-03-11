using Microsoft.EntityFrameworkCore;

namespace Darvyn_Lavandier_P2_AP1.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Encuesta> Encuestas { get; set; }
        public DbSet<EncuestaDetalle> EncuestaDetalles { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ciudad>().HasData(
                new Ciudad { Id = 1, Nombre = "Santo Domingo" },
                new Ciudad { Id = 2, Nombre = "Santiago" },
                new Ciudad { Id = 3, Nombre = "San Francisco de Macoris" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}

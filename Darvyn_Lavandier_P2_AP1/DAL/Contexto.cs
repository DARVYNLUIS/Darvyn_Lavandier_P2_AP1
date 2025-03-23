using Microsoft.EntityFrameworkCore;

namespace Darvyn_Lavandier_P2_AP1.Models
{
    public class Contexto(DbContextOptions<Contexto> options) : DbContext(options)
    {
        public virtual DbSet<Encuesta> Encuestas { get; set; }
        public virtual DbSet<Ciudad> Ciudades { get; set; }

        public virtual DbSet<EncuestaDetalle> Detalles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ciudad>().HasData(
                new List<Ciudad>()
                {
            new()
            {
                CiudadesId = 1,
                Nombre = "San Francisco de Macoris",
                Monto = 0,

            },
            new()
            {
                CiudadesId = 2,
                Nombre = "La Romana",
                Monto = 0,
            },
            new()
            {
                CiudadesId = 3,
                Nombre = "Salcedo",
                Monto = 0,
            }

                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}

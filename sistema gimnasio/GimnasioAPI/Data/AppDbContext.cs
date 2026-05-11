using Microsoft.EntityFrameworkCore;
using GimnasioAPI.Models;


namespace GimnasioAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Esto le avisa a EF Core que debe crear una tabla llamada "Socios" basada en la clase Socio
        public DbSet<Socio> Socios { get; set; }
    }
}

// hola

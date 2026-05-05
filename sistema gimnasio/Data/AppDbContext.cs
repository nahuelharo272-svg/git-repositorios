using Microsoft.EntityFrameworkCore;
using GimnasioAPI.Models;

namespace GimnasioAPI.Data
{
    // Esta es la capa que se encarga exclusivamente de la persistencia
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Esto le dice al ORM que mapee la clase Socio a una tabla llamada "Socios" en MySQL
        public DbSet<Socio> Socios { get; set; }
    }
}
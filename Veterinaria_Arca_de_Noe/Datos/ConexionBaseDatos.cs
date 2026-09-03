using Veterinaria_Arca_de_Noe.Models;
using Microsoft.EntityFrameworkCore;

namespace Veterinaria_Arca_de_Noe.Datos
{
    public class ConexionBaseDatos : DbContext
    {
        
        public ConexionBaseDatos(DbContextOptions<ConexionBaseDatos> options) : base(options)
        {
        }

        // Mapeo de las tablas del sistema Arca de Noe
        public DbSet<Propietario> Propietarios { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }
        public DbSet<Cita> Citas { get; set; }
    }
}
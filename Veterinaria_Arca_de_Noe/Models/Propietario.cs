using Microsoft.AspNetCore.Components.Web;

namespace Veterinaria_Arca_de_Noe.Models
{
    public class Propietario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Estado { get; set; } = true;

        // Propiedad de navegación
        public ICollection<Mascota> Mascotas { get; set; } = new List<Mascota>();

    }
}

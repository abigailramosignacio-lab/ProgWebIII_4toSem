namespace Veterinaria_Arca_de_Noe.Models
{
    public class Mascota
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Especie { get; set; } = string.Empty;
        public string Raza { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public bool Estado { get; set; } = true;

        // Llave Foránea
        public int PropietarioId { get; set; }
        public Propietario? Propietario { get; set; }

        // Propiedad de navegación
        public ICollection<Cita> Citas { get; set; } = new List<Cita>();
    }
}

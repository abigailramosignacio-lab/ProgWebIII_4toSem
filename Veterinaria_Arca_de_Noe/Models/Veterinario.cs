namespace Veterinaria_Arca_de_Noe.Models
{
    public class Veterinario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public bool Estado { get; set; } = true;

        // Propiedad de navegación
        public ICollection<Cita> Citas { get; set; } = new List<Cita>();
    }
}

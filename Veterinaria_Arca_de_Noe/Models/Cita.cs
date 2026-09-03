namespace Veterinaria_Arca_de_Noe.Models
{
    public enum EstadoCita
    {
        Pendiente,
        Completada,
        Cancelada
    }
    public class Cita
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string Motivo { get; set; } = string.Empty;
        public EstadoCita EstadoCita { get; set; } = EstadoCita.Pendiente;
        public string? Diagnostico { get; set; }

        // Relación con Mascota
        public int MascotaId { get; set; }
        public Mascota? Mascota { get; set; }

        // Relación con Veterinario
        public int VeterinarioId { get; set; }
        public Veterinario? Veterinario { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Veterinaria_Arca_de_Noe.Models
{
    public class Mascota
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Especie { get; set; } = string.Empty;

        [Required]
        public string Raza { get; set; } = string.Empty;

        public string Color { get; set; } = string.Empty; // Campo solicitado

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        public bool Estado { get; set; } = true;

        // Relación con Propietario
        public int PropietarioId { get; set; }
        public Propietario? Propietario { get; set; }
    }
}
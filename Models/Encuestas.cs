using System.ComponentModel.DataAnnotations;

namespace Ralfy_Genao_P2_AP1.Models
{
    public class Encuestas
    {
        [Key]
        public int EncuestasId { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "La asignatura es obligatoria")]
        public string? Asignatura { get; set; }

        public virtual ICollection<EncuestaDetalles> EncuestaDetalles { get; set; } = new List<EncuestaDetalles>();
    }
}

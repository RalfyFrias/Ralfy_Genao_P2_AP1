using System.ComponentModel.DataAnnotations;

namespace Ralfy_Genao_P2_AP1.Models
{
    public class Ciudades 
    {
        [Key]
        public int CiudadesId { get; set; }
        public string? Nombre { get; set; }
        
        public decimal Monto {  get; set; }
    
    }
}

using System.ComponentModel.DataAnnotations;

namespace Ralfy_Genao_P2_AP1.Models
{
    public class Ciudades 
    {
        [Key]
        public int CiudadId { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto {  get; set; }
        public string Asignatura { get; set; }


    }
}

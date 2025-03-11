using static Azure.Core.HttpHeader;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ralfy_Genao_P2_AP1.Models
{
    public class CiudadDetalle
    {
        [Key]
        public int DetalleId { get; set; }
        public int CiudadId { get; set; }
        public int Monto { get; set; }
        [ForeignKey("CiudadId")]
        public Ciudades? Ciudades { get; set; }
    }
}

using static Azure.Core.HttpHeader;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ralfy_Genao_P2_AP1.Models
{
    public class EncuestaDetalles
    {
        [Key]
        public int DetallesId { get; set; }
        public int EncuestaId { get; set; } 
        public int CiudadId { get; set; }
        public int MontoEncuesta { get; set; }
        [ForeignKey("CiudadId")]
        public virtual Ciudades Ciudad{ get; set; }
    }
}

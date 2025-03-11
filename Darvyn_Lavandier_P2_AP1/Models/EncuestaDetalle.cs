using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Darvyn_Lavandier_P2_AP1.Models;
public class EncuestaDetalle
{
    public int Id { get; set; }
    public int EncuestaId { get; set; }
    public Encuesta Encuesta { get; set; }

    public int CiudadId { get; set; }
    [ForeignKey("CiudadId")]
    public Ciudad Ciudad { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    public decimal Monto { get; set; }
}

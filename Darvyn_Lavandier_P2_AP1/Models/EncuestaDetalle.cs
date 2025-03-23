using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Darvyn_Lavandier_P2_AP1.Models;
public class EncuestaDetalle
{
    [Key]
    public int DestallesId { get; set; }

    public int EncuestaId { get; set; }

    public int CiudadId { get; set; }

    public int MontoEncuesta { get; set; }

    [ForeignKey("CiudadId")]
    public virtual Ciudad Ciudad { get; set; } = null!;
}


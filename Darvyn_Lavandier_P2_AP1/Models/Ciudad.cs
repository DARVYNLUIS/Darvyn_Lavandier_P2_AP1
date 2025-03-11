using System.ComponentModel.DataAnnotations;

public class Ciudad
{
    public int Id { get; set; }

    [Required]
    public string Nombre { get; set; }

    public List<EncuestaDetalle> EncuestaDetalles { get; set; } = new List<EncuestaDetalle>();
}


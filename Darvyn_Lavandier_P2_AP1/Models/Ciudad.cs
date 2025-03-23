using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Ciudad
{
    [Key]
    public int CiudadesId { get; set; }

    public string? Nombre { get; set; }

    public int Monto { get; set; }
}


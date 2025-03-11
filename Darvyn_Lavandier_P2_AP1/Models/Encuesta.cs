using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Darvyn_Lavandier_P2_AP1.Models
{   
public class Encuesta
{
    public int EncuestaId { get; set; }

        [Required(ErrorMessage = "El monto es obligatorio")]
        [Range(1, 1000000, ErrorMessage = "El monto debe ser mayor que cero")]
        public decimal Monto { get; set; }


        [Required(ErrorMessage = "El nombre es obligatorio")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Solo se permiten letras")]
        public string Asignatura { get; set; }

    [Required]
    public DateTime Fecha { get; set; }

    public List<EncuestaDetalle> Detalles { get; set; } = new List<EncuestaDetalle>();
}
}
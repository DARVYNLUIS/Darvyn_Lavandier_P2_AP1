using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Darvyn_Lavandier_P2_AP1.Models
{
    public class Encuesta
    {
        [Key]
        public int EncuestasId { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "La asignatura es obligatoria")]
        public string? Asignatura { get; set; }

        public virtual ICollection<EncuestaDetalle> EncuestaDetalles { get; set; } = new List<EncuestaDetalle>();
    }
}
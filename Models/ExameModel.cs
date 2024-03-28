using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intelectah.Models
{
    public class ExameModel
    {
        public int Id { get; set; }

        [ForeignKey("TipoExame")]
        public int TipoExameId { get; set; }

        [Required(ErrorMessage ="Informe ")]
        
    }
}

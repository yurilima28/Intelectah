using System.ComponentModel.DataAnnotations;

namespace Intelectah.Models
{
    public class TipoExameModel
    {
       public int Id { get; set; }

        [Required(ErrorMessage ="Infome o tipo de exame")]
        [MaxLength(100)]
        public string TipoExame { get; set; }

        [MaxLength(256)]
        public string Descricao { get; set; }   
    }
}

using System.ComponentModel.DataAnnotations;

namespace Intelectah.Models
{
    public class TipoExameModel
    {
       public int Id { get; set; }

        [Required(ErrorMessage ="Nome do tipo de exame é obrigatório")]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string Descricao { get; set; }   
    }
}

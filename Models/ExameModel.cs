using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intelectah.Models
{
    public class ExameModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Informe o nome do exame ")]
        [MaxLength(100)]
        public string NomeExame { get; set; }

        [MaxLength(1000)]
        public string Observacoes { get; set; }

        [ForeignKey("TipoExame")]
        public int tipoExameId {  get; set; }
        
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intelectah.Models
{
    public class ConsultaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Infome a data e o horario da consulta")]
        [Display(Name ="Data e Hora")]
        public DateTime DataHora { get; set; } = DateTime.Now.ToLocalTime();


        [ForeignKey("Exame")]
        public int Exame { get; set; }

        [ForeignKey("Paciente")]
        public int Paciente { get; set; }

        [ForeignKey("TipoExame")]
        public int TipoExame { get; set; }

        public string Protocolo { get; set; }
    }
}

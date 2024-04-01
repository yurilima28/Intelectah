using Intelectah.Data;
using System.ComponentModel.DataAnnotations;
using static Agendamento.Validator.CpfValidacao;

namespace Intelectah.Models
{
    public class PacienteModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do paciente")]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage ="CPF é obrigatório")]
        [Cpf(ErrorMessage = "CPF informador é inválido")]
        public string CPF {  get; set; }

        [Required(ErrorMessage ="Informe a data de nascimente")]
        [DataType(DataType.Date)]
        public string DataDeNascimento { get; set; }

        [Required(ErrorMessage ="Informe o sexo do paciente")]
        public string Sexo {  get; set; }


        [Required(ErrorMessage ="Informe o telefone do paciente")]
        [MaxLength(16)]
        public string Telefone { get; set; }

        [Required(ErrorMessage ="Informe o E-mail")]
        [EmailAddress(ErrorMessage = "E-mail informado é inválido")]
        public string Email { get; set; }

        public bool IsCpfUnique(BancoContext context)

        {
            return !context.Pacientes.Any(p => p.Id !=this.Id && p.CPF == this.CPF);
        }

    }
}

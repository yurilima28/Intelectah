using Intelectah.Data;
using Intelectah.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Intelectah.Repository
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly BancoContext _bancoContext;
        private readonly ILogger<PacienteModel> _logger;

        public PacienteRepository(BancoContext bancoContext, ILogger<PacienteModel> logger)
        {
            _bancoContext = bancoContext;
            _logger = logger;
        }
        public bool CPFUnico(string CPF)
        {
            return !_bancoContext.Pacientes.Any(p=> p.CPF == CPF);
        }
        public List <PacienteModel> BuscarTodos()
        {
            return _bancoContext.Pacientes.ToList();
        }
        public PacienteModel ListarPorId(int id)
        {
            return _bancoContext.Pacientes.FirstOrDefault(x => x.Id == id);
        }
        public PacienteModel BuscarPorId(int id)
        {
            return _bancoContext.Pacientes.FirstOrDefault(p => p.Id == id);
        }

        public List<PacienteModel> BuscarPorNomeCpf(string filtro)
        {
            try
            {
                if (string.IsNullOrEmpty(filtro))
                {
                    return new List<PacienteModel>();
                }
            }
            catch(Exception ex) 
            {
                _logger.LogError($"Erro ao buscar o paciente por nome ou CPF: {ex.Message}");
                throw;
            }
            return _bancoContext.Pacientes
                .Where(p => EF.Functions.Like(p.Nome, $"%{filtro}%") || EF.Functions.Like(p.CPF, $"%{filtro}%")).ToList();
        }
        public PacienteModel Adicionar(PacienteModel paciente)
        {
            _bancoContext.Pacientes.Add(paciente);
            _bancoContext.SaveChanges();
            return paciente;
        }
        public PacienteModel Atualizar(PacienteModel paciente)
        {
            PacienteModel pacienteDB = ListarPorId (paciente.Id);
            if (pacienteDB == null) throw new Exception("Houve um erro na atualização do paciente");
            pacienteDB.Nome = paciente.Nome;
            pacienteDB.CPF = paciente.CPF;
            pacienteDB.DataDeNascimento = paciente.DataDeNascimento;
            pacienteDB.Sexo = paciente.Sexo;
            pacienteDB.Telefone = paciente.Telefone;
            pacienteDB.Email = paciente.Email;

            _bancoContext.Pacientes.Update(pacienteDB);
            _bancoContext.SaveChanges();
            return pacienteDB;
        }

        public bool Apagar(int id)
        {
            PacienteModel pacienteDB = ListarPorId(id);
            if (pacienteDB == null) throw new Exception("Houve um erro na deleção do paciente");

            _bancoContext.Pacientes.Remove(pacienteDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}

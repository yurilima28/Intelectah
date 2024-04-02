using Intelectah.Data;
using Intelectah.Models;

namespace Intelectah.Repository
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly BancoContext _bancoContext;
        private readonly ILogger<ConsultaRepository> _logger;


        public ConsultaRepository(BancoContext bancoContext, ILogger<ConsultaRepository> logger)
        {
            _bancoContext = bancoContext;
            _logger = logger;
        }

        public List<ConsultaModel>BuscarTodos()
        {
            return _bancoContext.Consulta.ToList();
        }
        public ConsultaModel ListarPorId(int id)
        {
            try
            {
                return _bancoContext.Consulta.FirstOrDefault(c => c.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao listar consulta por ID: {ex.Message}");
                throw;
            }
        }
        public List<ConsultaModel> BuscarPorPacienteId(int pacienteId)
        {
            return _bancoContext.Consulta
                .Where(c => c.PacienteId == pacienteId)
                .ToList();
        }

        public ConsultaModel Adicionar (ConsultaModel consulta)
        {
            if(DataHoraConflitante(consulta))
            {
                throw new Exception("Conflito de horário. Já existe uma consulta agendada neste horário");

            }
            _bancoContext.Consulta.Add(consulta);
            _bancoContext.SaveChanges();
            return consulta;
        }

        public bool Apagar(int id)
        {
            ConsultaModel consultaDB = ListarPorId(id);
            if(consultaDB == null) throw new Exception("Houve um erro ao excluir a consulta");

            _bancoContext.Consulta.Remove(consultaDB);
            _bancoContext.SaveChanges();
            return true;
        }

        public ConsultaModel Atualizar(ConsultaModel consulta)
        {
            ConsultaModel consultaDB = ListarPorId(consulta.Id);
            if(consultaDB == null) throw new Exception("Houve um erro ao atualizar a consulta");

            consultaDB.ExameId = consulta.ExameId;
            consultaDB.PacienteId = consulta.PacienteId;
            consultaDB.DataHora = consulta.DataHora;
            consulta.Protocolo = consulta.Protocolo;

            _bancoContext.Consulta.Update(consultaDB);
            _bancoContext.SaveChanges();
            return consultaDB; 

        }


        public bool DataHoraConflitante(ConsultaModel novaConsulta)
        {
            try
            {
                return (_bancoContext.Consulta.Any(c => 
                c.DataHora == novaConsulta.DataHora
                && c.ExameId == novaConsulta.ExameId
                && c.Id != novaConsulta.Id));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao verificar conflito de data e hora: {ex.Message}");
                throw;
            }
        }
    }
}

using Intelectah.Data;
using Intelectah.Models;

namespace Intelectah.Repository
{
    public class ExameRepository : IExameRepository
    {
        private readonly BancoContext _bancoContext;

        public ExameRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public List<ExameModel> BuscarTodos()
        {
            return _bancoContext.Exames.ToList();
        }
        public ExameModel ListarPorId(int id) 
        {
            return _bancoContext.Exames.FirstOrDefault(e => e.Id == id);
        }
        public List<ExameModel>BuscarPorTipoExame(int tipoExameId)
        {
            return _bancoContext.Exames.Where(e => e.TipoExameId == tipoExameId).ToList();
        }
        public List<ExameModel> BuscarPorNome(string nome)
        {
            return _bancoContext.Exames.Where(e=> e.NomeExame.Contains(nome)).ToList();
        }

        public ExameModel Adicionar(ExameModel exame)
        {

            _bancoContext.Exames.Add(exame);
            _bancoContext.SaveChanges();
            return exame;
        }
        public ExameModel Atualizar(ExameModel exame)
        {
            ExameModel exameDB = ListarPorId(exame.Id);
            if(exameDB == null) throw new Exception("Houve um erro na atualização do exame");

            exameDB.TipoExameId = exame.TipoExameId;
            exameDB.NomeExame = exame.NomeExame;
            exameDB.Observacoes = exame.Observacoes;

            _bancoContext.Exames.Update(exameDB);
            _bancoContext.SaveChanges();

            return exameDB;
        }

        public bool Apagar(int id)
        {
            ExameModel exameDB = ListarPorId(id);
            if(exameDB == null) throw new Exception("Houve um erro ao deletar o exame");

            _bancoContext.Exames.Remove(exameDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}

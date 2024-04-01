using Intelectah.Data;
using Intelectah.Models;

namespace Intelectah.Repository
{
    public class TipoExameRepository : ITipoExameRepository
    {
        private readonly BancoContext _bancoContext;

        public TipoExameRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<TipoExameModel> BuscarTodosExames()
        {
            return _bancoContext.TipoExames.ToList();
        }

        public TipoExameModel ListarPorId(int id) 
        {
            return _bancoContext.TipoExames.FirstOrDefault(x => x.Id == id);
        }

        public TipoExameModel Adicionar(TipoExameModel tipoExame)
        {
            _bancoContext.TipoExames.Add(tipoExame);
            _bancoContext.SaveChanges();
            return tipoExame;

        }
        public  TipoExameModel Atualizar(TipoExameModel tipoExame) 
        {
            TipoExameModel tipoExameDB = ListarPorId(tipoExame.Id);
            if (tipoExameDB == null) throw new Exception("Houve um erro na atualização do exame");

            tipoExameDB.TipoExame = tipoExame.TipoExame;
            tipoExameDB.Descricao = tipoExame.Descricao;

            _bancoContext.TipoExames.Update(tipoExameDB);
            _bancoContext.SaveChanges();

            return tipoExameDB;

        }

        public bool Apagar(int id)
        {
            TipoExameModel tipoExameDB = ListarPorId(id);
            if (tipoExameDB == null) throw new Exception("Houve um erro ao deletar o tipo deexame");

            _bancoContext.TipoExames.Remove(tipoExameDB);
            _bancoContext.SaveChanges();

            return true;
        }




    }
}

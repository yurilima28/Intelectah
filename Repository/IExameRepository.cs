using Intelectah.Models;

namespace Intelectah.Repository
{
    public interface IExameRepository 
    {
        ExameModel ListarPorId(int id);
        List<ExameModel> BuscarTodos();
        List<ExameModel> BuscarPorNome(string nome);
        ExameModel Adicionar(ExameModel exame);
        ExameModel Atualizar(ExameModel exame);
        bool Apagar(int id);
        List<ExameModel> BuscarPorTipoExame(int tipoExameId);

    }
}

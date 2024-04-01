using Intelectah.Models;

namespace Intelectah.Repository
{
    public interface IConsultaRepository
    {
        ConsultaModel ListarPorId(int id);
        List <ConsultaModel> BuscarTodos();

        ConsultaModel Adicionar(ConsultaModel consulta);
        ConsultaModel Atualizar(ConsultaModel consulta);

        bool DataHoraConflitante (ConsultaModel consulta);

        bool Apagar(int id);

    }
}

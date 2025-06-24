using GumpFinanca.Domain.Entities;

namespace GumpFinanca.Domain.Repositories;

public interface ITransactionRepository : IBaseRepository<Transaction>
{
    Task<Transaction?> ConsultarPorId(int id);
    Task<IEnumerable<Transaction>> ConsultarTodos();
}

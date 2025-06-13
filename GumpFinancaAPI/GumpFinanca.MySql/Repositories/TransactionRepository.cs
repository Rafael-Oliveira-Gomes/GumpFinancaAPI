using GumpFinanca.Domain.Entities;
using GumpFinanca.Domain.Repositories;
using GumpFinanca.MySql.Context;
using Microsoft.EntityFrameworkCore;

namespace GumpFinanca.MySql.Repositories;

public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
{
    public TransactionRepository(MySqlContext context) : base(context)
    {
    }
    public async Task<Transaction?> ConsultarPorId(int id)
    {
        return await _context.Transactions.FindAsync(id);
    }
    public async Task<IEnumerable<Transaction>> ConsultarTodos()
    {
        return await _context.Transactions.ToListAsync();
    }
}

using GumpFinanca.Domain.Entities.Queries;
using GumpFinanca.Domain.Entities.ViewModel;
using GumpFinanca.Domain.Repositories;
using MediatR;

namespace GumpFinanca.Application.Handlers;

public class ConsultarTransactionHandler(ITransactionRepository transactionRepository) : IRequestHandler<TransactionQuery, IEnumerable<TransactionViewModel>>
{
    public async Task<IEnumerable<TransactionViewModel>> Handle(TransactionQuery request, CancellationToken cancellationToken)
    {
        var transactions = await transactionRepository.ConsultarTodos();
        return transactions.Select(t => new TransactionViewModel(t));
    }
}

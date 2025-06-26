using GumpFinanca.Domain.Entities;
using GumpFinanca.Domain.Entities.Command;
using GumpFinanca.Domain.Entities.ViewModel;
using GumpFinanca.Domain.Repositories;
using MediatR;

namespace GumpFinanca.Application.Handlers;

public class IncluirTransactionHandler(ITransactionRepository transactionRepository) : IRequestHandler<IncluirTransactionCommand, TransactionViewModel>
{
    public async Task<TransactionViewModel> Handle(IncluirTransactionCommand request, CancellationToken cancellationToken)
    {
        var transaction = new Transaction
        {
            Description = request.Description,
            Amount = request.Amount,
            Date = request.Date,
            Category = request.Category,
            Type = request.Type
        };
        await transactionRepository.AddAsync(transaction);
        return new TransactionViewModel(transaction);
    }
}

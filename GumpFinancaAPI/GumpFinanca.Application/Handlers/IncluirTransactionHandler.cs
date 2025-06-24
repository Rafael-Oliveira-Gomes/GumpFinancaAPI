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
            Description = request.description,
            Amount = request.amount,
            Date = request.date,
            Category = request.category,
            Type = request.type
        };
        await transactionRepository.AddAsync(transaction);
        return new TransactionViewModel(transaction);
    }
}

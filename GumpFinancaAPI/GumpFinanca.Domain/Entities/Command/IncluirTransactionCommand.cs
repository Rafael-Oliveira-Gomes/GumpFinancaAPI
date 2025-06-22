using GumpFinanca.Domain.Entities.ViewModel;
using MediatR;

namespace GumpFinanca.Domain.Entities.Command;

public record class IncluirTransactionCommand(int id, string description, decimal amount, DateTime date, string category, string type) : IRequest<TransactionViewModel>;

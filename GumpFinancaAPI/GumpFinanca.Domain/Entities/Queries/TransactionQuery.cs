using GumpFinanca.Domain.Entities.ViewModel;
using MediatR;

namespace GumpFinanca.Domain.Entities.Queries;

public class TransactionQuery() : IRequest<IEnumerable<TransactionViewModel>>;
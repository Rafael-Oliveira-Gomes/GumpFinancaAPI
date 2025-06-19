namespace GumpFinanca.Domain.Entities.ViewModel;

public record class TransactionViewModel(
    int Id,
    string Description,
    decimal Amount,
    DateTime Date,
    string Category,
    string Type
    )
{
    public TransactionViewModel(Transaction transaction) : this(transaction.Id, transaction.Description, transaction.Amount, transaction.Date, transaction.Category, transaction.Type) { }
}

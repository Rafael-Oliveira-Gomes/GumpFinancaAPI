using System.ComponentModel.DataAnnotations;
using GumpFinanca.Domain.Entities.ViewModel;
using MediatR;

namespace GumpFinanca.Domain.Entities.Command;

public record class IncluirTransactionCommand : IRequest<TransactionViewModel>
{
    public int Id { get; init; }
    [Required(ErrorMessage = "A descrição é obrigatória!")]
    public string Description { get; init; } = string.Empty;
    [Required(ErrorMessage = "O valor é obrigatório!")]
    public decimal Amount { get; init; }
    [Required(ErrorMessage = "A data é obrigatória!")]
    public DateTime Date { get; init; }
    [Required(ErrorMessage = "A categoria é obrigatória!")]
    public string Category { get; init; } = string.Empty;
    [Required(ErrorMessage = "O tipo é obrigatório!")]
    public string Type { get; init; } = string.Empty;
    public IncluirTransactionCommand(int id, string description, decimal amount, DateTime date, string category, string type)
    {
        Id = id;
        Description = description;
        Amount = amount;
        Date = date;
        Category = category;
        Type = type;
    }
}
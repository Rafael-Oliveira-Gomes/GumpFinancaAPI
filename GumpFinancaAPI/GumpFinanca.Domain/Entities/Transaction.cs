namespace GumpFinanca.Domain.Entities;

public class Transaction
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;

    public Transaction(string description, decimal amount, DateTime date, string category, string type)
    {
        Description = description;
        Amount = amount;
        Date = date;
        Category = category;
        Type = type;
    }
    public Transaction()
    {
    }
}

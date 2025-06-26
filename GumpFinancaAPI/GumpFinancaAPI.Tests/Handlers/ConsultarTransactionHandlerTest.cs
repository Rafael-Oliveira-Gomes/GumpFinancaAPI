using GumpFinanca.Application.Handlers;
using GumpFinanca.Domain.Entities;
using GumpFinanca.Domain.Entities.Queries;
using GumpFinanca.Domain.Repositories;
using Moq;

namespace GumpFinancaAPI.Tests.Handlers;

public class ConsultarTransactionHandlerTest
{
    [Fact]
    public async Task Handle_DeveRetornarListaDeTransactionViewModel_QuandoExistiremTransacoes()
    {
        // Arrange
        var transactions = new List<Transaction>
        {
            new(null, 5000m, new DateTime(2024, 6, 5), "Receita", "Receita")
        };

        var mockRepo = new Mock<ITransactionRepository>();
        mockRepo.Setup(r => r.ConsultarTodos()).ReturnsAsync(transactions);

        var handler = new ConsultarTransactionHandler(mockRepo.Object);
        var query = new TransactionQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        var resultList = result.ToList();
        Assert.Equal(1, resultList.Count);
        Assert.NotEmpty(resultList[0].Description);
    }

    [Fact]
    public async Task Handle_DeveRetornarListaVazia_QuandoNaoExistiremTransacoes()
    {
        // Arrange
        var mockRepo = new Mock<ITransactionRepository>();
        mockRepo.Setup(r => r.ConsultarTodos()).ReturnsAsync(new List<Transaction>());

        var handler = new ConsultarTransactionHandler(mockRepo.Object);
        var query = new TransactionQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }
}

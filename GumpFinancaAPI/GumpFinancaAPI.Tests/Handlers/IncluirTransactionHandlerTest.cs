using GumpFinanca.Application.Handlers;
using GumpFinanca.Domain.Entities.Command;
using GumpFinanca.Domain.Repositories;
using Moq;

namespace GumpFinancaAPI.Tests.Handlers;

public class IncluirTransactionHandlerTest
{
    [Fact]
    public async Task Handle_DeveAdicionarTransacaoERetornarViewModel()
    {
        // Arrange
        var mockRepo = new Mock<ITransactionRepository>();
        mockRepo.Setup(r => r.AddAsync(It.IsAny<GumpFinanca.Domain.Entities.Transaction>()))
                .Returns(Task.CompletedTask)
                .Verifiable();

        var handler = new IncluirTransactionHandler(mockRepo.Object);

        var command = new IncluirTransactionCommand(
            id: 0,
            description: "Compra Supermercado",
            amount: 150.75m,
            date: new DateTime(2024, 6, 25),
            category: "Alimentação",
            type: "Despesa"
        );

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        mockRepo.Verify(r => r.AddAsync(It.IsAny<GumpFinanca.Domain.Entities.Transaction>()), Times.Once);
        Assert.NotNull(result);
        Assert.Equal(command.Description, result.Description);
        Assert.Equal(command.Amount, result.Amount);
        Assert.Equal(command.Date, result.Date);
        Assert.Equal(command.Category, result.Category);
        Assert.Equal(command.Type, result.Type);
    }
}

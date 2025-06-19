using GumpFinanca.Domain.Entities.Command;
using GumpFinanca.Domain.Entities.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GumpFinancaAPI.Controllers.v1;

/// <summary>
/// Controller responsável pelas operações de transações financeiras.
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public class transactionController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Construtor do TransactionController.
    /// </summary>
    /// <param name="mediator">Instância do MediatR para envio de comandos.</param>
    public transactionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Cria uma nova transação financeira.
    /// </summary>
    /// <param name="command">Comando para inclusão de transação.</param>
    /// <returns>Dados da transação criada.</returns>
    /// <response code="201">Transação criada com sucesso.</response>
    [HttpPost]
    [ProducesResponseType(typeof(TransactionViewModel), StatusCodes.Status201Created)]
    public async Task<ActionResult<TransactionViewModel>> Post([FromBody] IncluirTransactionCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(Post), new { id = result.Id }, result);
    }
}

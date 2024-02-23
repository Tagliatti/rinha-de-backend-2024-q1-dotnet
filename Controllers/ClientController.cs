using Microsoft.AspNetCore.Mvc;
using RinhaBackend2024Q1.Entities;
using RinhaBackend2024Q1.Exceptions;
using RinhaBackend2024Q1.Repositories;
using RinhaBackend2024Q1.Services;
using RinhaBackend2024Q1.ViewModel;

namespace RinhaBackend2024Q1.Controllers
{
    [Route("clientes")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly TransactionService _transactionService;

        public ClientController(TransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost("{id}/transacoes", Name = "Transações")]
        public async Task<IActionResult> Transactions([FromRoute] int id, Transaction transaction)
        {
            try
            {
                transaction.ClientId = id;
                var client = await _transactionService.Handle(transaction);

                return client is null ? NotFound() : Ok(client);
            }
            catch (DomainException exception)
            {
                return UnprocessableEntity(exception.Message);
            }
        }

        [HttpGet("{id}/extrato", Name = "Extrato")]
        public async Task<IActionResult> Statement(int id, [FromServices] ClientRepository clientRepository,
            [FromServices] TransactionRepository transactionRepository)
        {
            var client = await clientRepository.FindByIdAsync(id);
            if (client is null)
            {
                return NotFound();
            }

            var transactions = await transactionRepository.ListLatestAsync(id);

            return Ok(new StatementViewModel(client, transactions));
        }
    }
}
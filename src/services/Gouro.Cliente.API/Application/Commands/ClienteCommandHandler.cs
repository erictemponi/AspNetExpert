using FluentValidation.Results;
using Gouro.Clientes.API.Models;
using Gouro.Core.Messages;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Gouro.Clientes.API.Application.Commands
{
    public class ClienteCommandHandler : CommandHandler, IRequestHandler<RegistrarClienteCommand, ValidationResult>
    {
        public async Task<ValidationResult> Handle(RegistrarClienteCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var cliente = new Cliente(message.Id, message.Nome, message.Email, message.Cpf);

            // Validações de negócio


            // Persistência no banco


            return message.ValidationResult;
        }
    }
}

using Gouro.Core.Mediator;
using Gouro.WebApi.Core.Controllers;
using Gouro.WebApi.Core.Usuario;
using Microsoft.AspNetCore.Authorization;

namespace Gouro.Pedidos.API.Controllers
{
    [Authorize]
    public class PedidoController : MainController
    {
        private readonly IMediatorHandler _mediator;
        private readonly IAspNetUser _user;

        public PedidoController(IMediatorHandler mediator, IAspNetUser user)
        {
            _mediator = mediator;
            _user = user;
        }
    }
}

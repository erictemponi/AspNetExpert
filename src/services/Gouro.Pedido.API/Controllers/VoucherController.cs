using Microsoft.AspNetCore.Authorization;
using Gouro.WebApi.Core.Controllers;
using Gouro.WebApi.Core.Usuario;
using Gouro.Pedidos.Infra.Data;

namespace Gouro.Pedidos.API.Controllers
{
    [Authorize]
    public class VoucherController : MainController
    {
        private readonly IAspNetUser _user;
        private readonly PedidosContext _context;

        public VoucherController(IAspNetUser user, PedidosContext context)
        {
            _user = user;
            _context = context;
        }
    }
}
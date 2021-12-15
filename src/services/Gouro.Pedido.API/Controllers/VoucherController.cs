using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Gouro.Pedidos.API.Application.DTO;
using Gouro.Pedidos.API.Application.Queries;
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
        private readonly IVoucherQueries _voucherQueries;

        public VoucherController(IAspNetUser user, PedidosContext context, IVoucherQueries voucherQueries)
        {
            _user = user;
            _context = context;
            _voucherQueries = voucherQueries;
        }

        [HttpGet("voucher/{codigo}")]
        [ProducesResponseType(typeof(VoucherDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ObterPorCodigo(string codigo)
        {
            if (string.IsNullOrEmpty(codigo)) return NotFound();

            var voucher = await _voucherQueries.ObterVoucherPorCodigo(codigo);

            return voucher == null ? NotFound() : CustomResponse(voucher);
        }
    }
}
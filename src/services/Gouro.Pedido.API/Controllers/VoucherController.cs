﻿using Microsoft.AspNetCore.Authorization;
using Gouro.WebApi.Core.Controllers;
using Gouro.WebApi.Core.Usuario;
using Gouro.Pedidos.Infra.Data;
using Gouro.Pedidos.API.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Gouro.Pedidos.API.Application.DTO;
using System.Net;

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
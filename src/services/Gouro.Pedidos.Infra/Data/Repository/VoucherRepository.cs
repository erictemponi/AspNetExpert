﻿using Gouro.Core.Data;
using Gouro.Pedidos.Domain.Vouchers;

namespace Gouro.Pedidos.Infra.Data.Repository
{
    public class VoucherRepository : IVoucherRepository
    {
        private readonly PedidosContext _context;

        public VoucherRepository(PedidosContext context)
        {
            _context = context;
        }

        public IUnityOfWork UnityOfWork => _context;

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

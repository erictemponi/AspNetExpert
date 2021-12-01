﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Gouro.Core.Data;

namespace Gouro.Clientes.API.Models
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        void Adicionar(Cliente cliente);

        Task<IEnumerable<Cliente>> ObterTodos();
        Task<Cliente> ObterPorCpf(string cpf);
    }
}
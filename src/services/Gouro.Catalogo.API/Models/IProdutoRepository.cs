using Gouro.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gouro.Catalogo.API.Models
{
    interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterTodos();
        Task<Produto> ObterPorId(Guid id);

        void Adicionar(Produto produto);
        void Atualizar(Produto produto);

    }
}

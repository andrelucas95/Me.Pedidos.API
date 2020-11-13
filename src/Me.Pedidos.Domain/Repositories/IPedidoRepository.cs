using System.Collections.Generic;
using System.Threading.Tasks;
using Me.Pedidos.Domain.Core;
using Me.Pedidos.Domain.DomainObjects;

namespace Me.Pedidos.Domain.Repositories
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        void Add(Pedido pedido);
        Task<Pedido> BuscarPorCodigo(string codigo);
        Task<List<Pedido>> ObterTodos();
    }
}
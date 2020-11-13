using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Me.Pedidos.Domain.Core;
using Me.Pedidos.Domain.DomainObjects;
using Me.Pedidos.Domain.Repositories;
using Me.Pedidos.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace tests.Fakes
{
    public class FakePedidoRepository : IPedidoRepository
    {
        private readonly PedidosDbContext _context;

        public FakePedidoRepository(PedidosDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Add(Pedido pedido)
        {
            _context.Add(pedido);
        }

        public async Task<Pedido> BuscarPorCodigo(string codigo)
        {
            return await _context.Pedidos
                .Where(p => p.CodigoPedido == codigo)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Pedido>> ObterTodos()
        {
            return await _context.Pedidos.ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
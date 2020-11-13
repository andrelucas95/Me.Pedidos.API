using System.Collections.Generic;
using Me.Pedidos.Domain.DomainObjects;

namespace tests.Factories
{
    public static class CreatePedidoFactory
    {
        public static Pedido Build()
        {
            return new Pedido(
                "123456", 
                new List<ItemPedido>()
                { 
                    new ItemPedido("Item A", 10, 1),
                    new ItemPedido("Item B", 5, 2)
                });
        }
    }
}
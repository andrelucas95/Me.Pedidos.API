namespace Me.Pedidos.API.Models.Errors
{
    public class CodigoPedidoInvalidoError : NotFoundError
    {
        public CodigoPedidoInvalidoError()
        {
            Status = "CODIGO_PEDIDO_INVALIDO";
        }
    }
}
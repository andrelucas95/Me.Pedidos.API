namespace Me.Pedidos.API.Models.Errors
{
    public class PedidoAprovadoValorAMaiorError : ProcessingError
    {
        public PedidoAprovadoValorAMaiorError()
        {
            Status = "APROVADO_VALOR_A_MAIOR";
        }
    }
}
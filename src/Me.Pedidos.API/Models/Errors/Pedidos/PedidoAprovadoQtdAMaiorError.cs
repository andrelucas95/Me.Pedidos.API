namespace Me.Pedidos.API.Models.Errors
{
    public class PedidoAprovadoQtdAMaiorError : ProcessingError
    {
        public PedidoAprovadoQtdAMaiorError()
        {
            Status = "APROVADO_QTD_A_MAIOR";
        }
    }
}
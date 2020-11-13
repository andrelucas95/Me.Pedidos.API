namespace Me.Pedidos.API.Models.Errors
{
    public class PedidoAprovadoQtdAMenorError : ProcessingError
    {
        public PedidoAprovadoQtdAMenorError()
        {
            Status = "APROVADO_QTD_A_MENOR";
        }
    }
}
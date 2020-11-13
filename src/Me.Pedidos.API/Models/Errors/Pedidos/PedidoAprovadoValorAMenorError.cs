namespace Me.Pedidos.API.Models.Errors
{
    public class PedidoAprovadoValorAMenorError : ProcessingError
    {
        public PedidoAprovadoValorAMenorError()
        {
            Status = "APROVADO_VALOR_A_MENOR";
        }
    }
}
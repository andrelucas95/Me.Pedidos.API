namespace Me.Pedidos.API.Models.Errors
{
    public class PedidoAprovadoError : ProcessingError
    {
        public PedidoAprovadoError()
        {
            Status = "APROVADO";
        }
    }
}
namespace Me.Pedidos.API.Models.Errors
{
    public class PedidoReprovadoError : ProcessingError
    {
        public PedidoReprovadoError()
        {
            Status = "REPROVADO";
        }
    }
}
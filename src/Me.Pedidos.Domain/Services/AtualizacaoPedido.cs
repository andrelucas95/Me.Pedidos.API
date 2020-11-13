namespace Me.Pedidos.Domain.Services
{
    public class AtualizacaoPedido
    {
        public AtualizacaoPedido() { }
        public AtualizacaoPedido(string status, int itensAprovados, decimal valorAprovado, string codigoPedido)
        {
            Status = status;
            ItensAprovados = itensAprovados;
            ValorAprovado = valorAprovado;
            CodigoPedido = codigoPedido;
        }

        public string Status { get; set; }
        public int ItensAprovados { get; set; }
        public decimal ValorAprovado { get; set; }
        public string CodigoPedido { get; set; }
    }
}
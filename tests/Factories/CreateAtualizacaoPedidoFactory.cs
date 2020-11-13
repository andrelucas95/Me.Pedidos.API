using Me.Pedidos.Domain.Services;

namespace tests.Factories
{
    public static class CreateAtualizacaoPedidoFactory
    {
        public static AtualizacaoPedido Build(this AtualizacaoPedido atualizacaoPedido)
        {
            return atualizacaoPedido;
        }

        public static AtualizacaoPedido Aprovado(this AtualizacaoPedido atualizacaoPedido)
        {
            atualizacaoPedido.Status = "APROVADO";
            atualizacaoPedido.ItensAprovados = 3;
            atualizacaoPedido.ValorAprovado = 20;
            atualizacaoPedido.CodigoPedido = "123456";

            return atualizacaoPedido;
        }

        public static AtualizacaoPedido AprovadoValorAMenor(this AtualizacaoPedido atualizacaoPedido)
        {
            atualizacaoPedido.Status = "APROVADO";
            atualizacaoPedido.ItensAprovados = 3;
            atualizacaoPedido.ValorAprovado = 10;
            atualizacaoPedido.CodigoPedido = "123456";

            return atualizacaoPedido;
        }

        public static AtualizacaoPedido AprovadoValorEQtdAMaior(this AtualizacaoPedido atualizacaoPedido)
        {
            atualizacaoPedido.Status = "APROVADO";
            atualizacaoPedido.ItensAprovados = 4;
            atualizacaoPedido.ValorAprovado = 21;
            atualizacaoPedido.CodigoPedido = "123456";

            return atualizacaoPedido;
        }

        public static AtualizacaoPedido AprovadoQtdAMenor(this AtualizacaoPedido atualizacaoPedido)
        {
            atualizacaoPedido.Status = "APROVADO";
            atualizacaoPedido.ItensAprovados = 2;
            atualizacaoPedido.ValorAprovado = 20;
            atualizacaoPedido.CodigoPedido = "123456";

            return atualizacaoPedido;
        }

        public static AtualizacaoPedido Reprovado(this AtualizacaoPedido atualizacaoPedido)
        {
            atualizacaoPedido.Status = "REPROVADO";
            atualizacaoPedido.ItensAprovados = 0;
            atualizacaoPedido.ValorAprovado = 0;
            atualizacaoPedido.CodigoPedido = "123456";

            return atualizacaoPedido;
        }

        public static AtualizacaoPedido CodigoPedidoInvalido(this AtualizacaoPedido atualizacaoPedido)
        {
            atualizacaoPedido.Status = "APROVADO";
            atualizacaoPedido.ItensAprovados = 3;
            atualizacaoPedido.ValorAprovado = 20;
            atualizacaoPedido.CodigoPedido = "123456-N";

            return atualizacaoPedido;
        }
    }
}
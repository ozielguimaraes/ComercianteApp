using Domain.AggregatesModels.Base;

namespace Domain.AggregatesModels.ProdutosAggregates
{
    public class Produto : EntityBase
    {
        public string IdFornecedor { get; private set; }
        public string Descricao { get; private set; }
        public int Quantidade { get; private set; }
        public string UnidadeMedida { get; private set; }
        public double PrecoCusto { get; private set; }
        public double PrecoVenda { get; private set; }

        public Produto(string idFornecedor, string descricao, int quantidade, string unidadeMedida, double precoCusto, double precoVenda)
        {
            IdFornecedor = idFornecedor;
            Descricao = descricao;
            Quantidade = quantidade;
            UnidadeMedida = unidadeMedida;
            PrecoCusto = precoCusto;
            PrecoVenda = precoVenda;
        }

        private Produto()
        {
        }
    }
}
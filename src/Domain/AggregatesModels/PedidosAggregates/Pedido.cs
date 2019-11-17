using Domain.AggregatesModels.Base;
using Domain.AggregatesModels.ClientesAggregates;
using Domain.AggregatesModels.PagamentosAggregates;
using Domain.AggregatesModels.ProdutosAggregates;
using Domain.AggregatesModels.RemessasAggregates;
using System.Collections.Generic;
using System.Linq;

namespace Domain.AggregatesModels.PedidosAggregates
{
    public class Pedido : EntityBase
    {
        public double Valor { get => ItensPedido.Select(s => s.Produto.PrecoVenda).Sum(); set => Valor = value; }

        public Cliente Cliente { get; private set; }
        public Remessa Remessa { get; private set; }
        public FormaPagamento FormaPagamento { get; private set; }

        public virtual IEnumerable<ItemPedido> ItensPedido => _itensPedido.AsReadOnly();

        private List<ItemPedido> _itensPedido = new List<ItemPedido>();

        public Pedido(Cliente cliente, FormaPagamento formaPagamento, Remessa remessa)
        {
            Cliente = cliente;
            FormaPagamento = formaPagamento;
            Remessa = remessa;
        }

        private Pedido()
        {
        }

        public void IncluirProduto(Produto produto)
        {
            _itensPedido.Add(new ItemPedido(this, produto));
        }
    }
}
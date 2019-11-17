using Domain.AggregatesModels.Base;
using Domain.AggregatesModels.ProdutosAggregates;

namespace Domain.AggregatesModels.PedidosAggregates
{
    public class ItemPedido : EntityBase
    {
        public Pedido Pedido { get; private set; }
        public Produto Produto { get; private set; }

        public ItemPedido(Pedido pedido, Produto produto)
        {
            Pedido = pedido;
            Produto = produto;
        }

        private ItemPedido()
        {
        }
    }
}
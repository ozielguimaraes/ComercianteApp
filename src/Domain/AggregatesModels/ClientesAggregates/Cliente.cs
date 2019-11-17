using Domain.AggregatesModels.Base;
using Domain.AggregatesModels.PedidosAggregates;
using System.Collections.Generic;

namespace Domain.AggregatesModels.ClientesAggregates
{
    public class Cliente : EntityBase
    {
        public string Nome { get; private set; }

        public virtual IEnumerable<Pedido> Pedidos => _pedidos.AsReadOnly();

        private List<Pedido> _pedidos = new List<Pedido>();

        public Cliente(string nome)
        {
            Nome = nome;
        }

        private Cliente()
        {
        }
    }
}
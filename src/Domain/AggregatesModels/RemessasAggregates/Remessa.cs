using Domain.AggregatesModels.Base;
using Domain.AggregatesModels.PedidosAggregates;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.AggregatesModels.RemessasAggregates
{
    public class Remessa : EntityBase
    {
        public DateTime DataPedido { get; private set; }
        public DateTime? DataEntrega { get; private set; }

        public double Valor
        {
            get => Pedidos.Select(s => s.Valor).Sum();
            private set => Valor = value;
        }

        public double Desconto
        {
            get => Valor * 0.03;
            private set => Desconto = value;
        }

        public double ValorFinal
        {
            get => Valor - Desconto;
            private set => ValorFinal = value;
        }

        public virtual IEnumerable<Pedido> Pedidos => _pedidos.AsReadOnly();

        private List<Pedido> _pedidos = new List<Pedido>();

        public Remessa(DateTime dataPedido)
        {
            DataPedido = dataPedido;
        }

        private Remessa()
        {
        }

        public void IncluirDataEntrega(DateTime dataEntrega)
        {
            DataEntrega = dataEntrega;
        }
    }
}
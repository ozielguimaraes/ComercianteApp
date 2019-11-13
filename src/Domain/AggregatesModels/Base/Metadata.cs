using System;

namespace Domain.AggregatesModels.Base
{
    public class Metadata
    {
        public DateTime Criacao { get; private set; } = DateTime.Now;
        public DateTime? Alteracao { get; private set; }
        public DateTime? Exclusao { get; private set; }

        public bool Ativo => Exclusao.HasValue || (Criacao >= DateTime.Now && DateTime.Now <= Exclusao);

        public Metadata()
        {
        }
    }
}
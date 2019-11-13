using System;

namespace Domain.AggregatesModels.Base
{
    public class EntityBase
    {
        public long Id { get; protected set; }
        public Guid Guid { get; protected set; }
    }
}
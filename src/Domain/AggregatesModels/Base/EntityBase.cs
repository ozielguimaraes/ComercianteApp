namespace Domain.AggregatesModels.Base
{
    public abstract class EntityBase
    {
        public long Id { get; protected set; }
        public virtual Metadata Metadata { get; private set; }

        public EntityBase()
        {
        }
    }
}
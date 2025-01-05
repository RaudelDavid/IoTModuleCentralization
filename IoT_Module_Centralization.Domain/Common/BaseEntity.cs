namespace IoT_Module_Centralization.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; } = Guid.NewGuid(); // Identificador único

        protected BaseEntity(){}

        protected BaseEntity(Guid id)
        {
            Id = id;
        }
    }
}  
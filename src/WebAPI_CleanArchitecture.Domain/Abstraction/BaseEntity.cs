namespace WebAPI_CleanArchitecture.Domain.Abstraction
{
    public class BaseEntity
    {
        protected BaseEntity() { }
        protected BaseEntity(Guid id) => Id = id;



        private readonly List<IDomainEvent> _domainEvents = [];
        public Guid Id { get; init; }
        public byte[] RowVersion { get; set; } = null!;


        public IReadOnlyList<IDomainEvent> GetDomainEvents()
            => _domainEvents.ToList();
        public void ClearDomainEvents()
            => _domainEvents.Clear();
        protected void RaiseDomainEvent(IDomainEvent domainEvent)
            => _domainEvents.Add(domainEvent);
    }
}

namespace WebAPI_CleanArchitecture.Domain.Abstraction
{
    public class BaseEntity
    {
        private readonly List<IDomainEvent> _domainEvents = [];


        ///<summary>
        /// Unique identifier for the entity using a Globally Unique Identifier (GUID).
        /// Uses a GUID to prevent ID guessing
        /// Using 'init' ensures the ID is immutable and cannot be changed after initialization.
        ///</summary> 
        public Guid Id { get; init; }

        //Optimistic Concurrency Control.
        public byte[] RowVersion { get; set; } = null!;




        /// <summary>
        /// Make it protected to prevent anyone to create instance from class BaseEntity using new word 
        /// define empty constructor because the EFCore Instantiation 
        /// define a parameterized constructor because if user want to create a new instance from class  
        /// that inherits this class(BaseEntity) he can initialize the Entity with a specific ID manually. 
        /// </summary>
        protected BaseEntity() { }
        protected BaseEntity(Guid id) => Id = id;




        /// <summary>
        /// IReadOnly : To prevent anyone outside the class to add or remove items from 
        /// _domainEvents List he can just read not add or delete
        /// </summary>
        public IReadOnlyList<IDomainEvent> GetDomainEvents()
            => _domainEvents.ToList();
        public void ClearDomainEvents()
            => _domainEvents.Clear();

        /// <summary>
        /// Allows derived entities (subclasses) to publish business events.
        /// </summary>
        protected void RaiseDomainEvent(IDomainEvent domainEvent)
            => _domainEvents.Add(domainEvent);
    }
}

namespace Bookify.Domain.Abstractions;

public abstract class Entity
{
    private readonly List<IDomainEvent> _domasEvents = new();
   
    protected Entity(Guid id)
    {
        Id = id;
    }

    protected Entity() {}
 
    public Guid Id { get; init; }
    
    public IReadOnlyList<IDomainEvent> GetDomainEvents() => _domasEvents.ToList();
   
    public void ClearDomainEvents()
    {
        _domasEvents.Clear();
    }

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domasEvents.Add(domainEvent);
    }
}

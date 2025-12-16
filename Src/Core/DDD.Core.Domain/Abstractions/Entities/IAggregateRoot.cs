using DDD.Core.Domain.Abstractions.Events;

namespace DDD.Core.Domain.Abstractions.Entities;

public interface IAggregateRoot
{
    IReadOnlyList<IDomainEvent> DomainEvents { get; }

    void AddDomainEvent(IDomainEvent newEvent);

    public IEnumerable<IDomainEvent> GetEvents();

    void ClearEvents();

    void RemoveDomainEvent(IDomainEvent eventItem);
}
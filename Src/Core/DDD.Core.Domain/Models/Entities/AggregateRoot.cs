using DDD.Core.Domain.Abstractions.Entities;
using DDD.Core.Domain.Abstractions.Events;

namespace DDD.Core.Domain.Models.Entities;

public abstract class AggregateRoot<TPrimaryKey> : Entity<TPrimaryKey>, IAggregateRoot
       where TPrimaryKey : struct,
             IComparable,
             IComparable<TPrimaryKey>,
             IConvertible,
             IEquatable<TPrimaryKey>,
             IFormattable
{
    private readonly List<IDomainEvent> _domainEvents;

    public virtual IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

    protected AggregateRoot()
    {
        _domainEvents = new List<IDomainEvent>();
    }

    public virtual void AddDomainEvent(IDomainEvent newEvent)
    {
        if (_domainEvents is null)
            throw new ArgumentNullException(nameof(newEvent));

        _domainEvents.Add(newEvent);
    }

    public virtual void RemoveDomainEvent(IDomainEvent eventItem)
    {
        if (_domainEvents is null)
            throw new ArgumentNullException(nameof(eventItem));

        _domainEvents.Remove(eventItem);
    }

    public virtual void ClearEvents()
    {
        _domainEvents.Clear();
    }
}
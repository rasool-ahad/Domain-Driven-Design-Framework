using DDD.Core.Domain.Abstractions.Events;

namespace DDD.Core.Contracts.ApplicationServices.Events;

public interface IDomainEventHandler<TDomainEvent> where TDomainEvent : IDomainEvent
{
    Task Handle(TDomainEvent Event);
}

using GeoChat.Geolocation.Api.EventBus.Events;

namespace GeoChat.Geolocation.Api.EventBus.EventHandlers;

public interface IEventHandler<TEvent> where TEvent : BaseEvent
{
    Task HandleAsync(TEvent @event);
}

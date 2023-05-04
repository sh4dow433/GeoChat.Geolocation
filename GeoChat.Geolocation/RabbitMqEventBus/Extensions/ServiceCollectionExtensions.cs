using GeoChat.Geolocation.Api.EventBus;
using GeoChat.Geolocation.Api.RabbitMqEventBus.ConnectionManager;
using GeoChat.Geolocation.Api.RabbitMqEventBus.EventsManager;

namespace GeoChat.Geolocation.Api.RabbitMqEventBus.Extensions;

public static class ServiceCollectionExtensions
{
    public static void RegisterEventBus(this IServiceCollection services)
    {
        services.AddSingleton<IEventManager, EventManager>();
        services.AddSingleton<IRabbitMqConnectionManager, RabbitMqConnectionManager>();
        services.AddSingleton<IEventBus, EventBus>();
    }
}

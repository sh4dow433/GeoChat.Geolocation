using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace GeoChat.Geolocation.Api.Hubs;

[Authorize]
public class RealTimeHub : Hub
{
    // to do
}

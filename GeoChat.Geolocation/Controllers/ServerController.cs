using GeoChat.Geolocation.Api.DbAccess;
using GeoChat.Geolocation.Api.Entities;
using GeoChat.Geolocation.Api.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace GeoChat.Geolocation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServerController : ControllerBase
{
	private readonly IGenericRepo<Server> serversRepository;
	private readonly IGenericRepo<Location> locationsRepository;

	[HttpGet("{latitude}/{longitude}")]
	[Authorize]
	public async Task<Server> GetServerUrl(double latitude, double longitude)
	{
		if (latitude < -90 || latitude > 90) throw new ArgumentException("Wrong latitude value!");
		if (longitude < -180 || latitude > 180) throw new ArgumentException("Wrong longitude value!");
		IGeoHasher geoHasher = new GeoHasher();
		String geoHashCode = geoHasher.getGeoHashCode(latitude, longitude);

		IEnumerable<Location> locations = await locationsRepository.GetAllAsync();
		Location location = locations.First(l => l.geoHashCode.Equals(geoHashCode));
		if (location == null) return null;

		Server? server = await serversRepository.GetAsync(location.serverId);
		if (server == null) return null;
		return server;
	}

	[HttpGet("{id}")]
	[Authorize]
	public async Task<Server> GetServerUrl(long id)
	{
		Server? server = await serversRepository.GetAsync(id);
		if (server == null) return null;
		return server;
	}

	[HttpGet("servers")]
	[Authorize]
	public async Task<IEnumerable<Server>> GetServers()
	{
		IEnumerable<Server> servers = await serversRepository.GetAllAsync();
		if (servers == null) return null;
		return servers;
	}
}

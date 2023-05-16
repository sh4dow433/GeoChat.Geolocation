using GeoChat.Geolocation.Api.Entities;
using GeoChat.Geolocation.Api.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;

namespace GeoChat.Geolocation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServerController : ControllerBase
{
    private readonly IGenericRepo<Server> serversRepository;
	private readonly IGenericRepo<Location> locationsRepository;
	private readonly IGeoHasher geoHasher;

	public ServerController(IGenericRepo<Server> serversRepository, IGenericRepo<Location> locationsRepository, IGeoHasher geoHasher)
	{
		this.serversRepository = serversRepository;
		this.locationsRepository = locationsRepository;
		this.geoHasher = geoHasher;
	}

	[HttpGet("{latitude}/{longitude}")]
	[Authorize]
	public async Task<IActionResult> GetServerUrl(double latitude, double longitude)
	{
		if (latitude < -90 || latitude > 90) return BadRequest();
		if (longitude < -180 || latitude > 180) return BadRequest();
        String geoHashCode = geoHasher.getGeoHashCode(latitude, longitude);

		IEnumerable<Location> locations = await locationsRepository.GetAllAsync();
		Location location = locations.First(l => geoHashCode.StartsWith(l.GeoHashCode));
		if (location == null) return NotFound();

		Server? server = await serversRepository.GetAsync(location.ServerId);
		if (server == null) return NotFound();
		return Ok(server);
	}

	[HttpGet("{id}")]
	[Authorize]
	public async Task<IActionResult> GetServerUrl(long id)
	{
		Server? server = await serversRepository.GetAsync(id);
		if (server == null) return NotFound();
		return Ok(server);
    }

	[HttpGet("servers")]
	[Authorize]
	public async Task<IActionResult> GetServers()
	{
		IEnumerable<Server> servers = await serversRepository.GetAllAsync();
		if (servers == null) return NotFound();
		return Ok(servers);
    }
}

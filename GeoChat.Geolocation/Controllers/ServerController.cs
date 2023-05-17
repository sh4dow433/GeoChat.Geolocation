using GeoChat.Geolocation.Api.Entities;
using GeoChat.Geolocation.Api.Repo;
using Geohash;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeoChat.Geolocation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServerController : ControllerBase
{
    private readonly IGenericRepo<Server> serversRepository;
	private readonly IGenericRepo<Location> locationsRepository;
	private readonly IConfiguration configuration;

	public ServerController(IGenericRepo<Server> serversRepository, IGenericRepo<Location> locationsRepository, IConfiguration configuration)
	{
		this.serversRepository = serversRepository;
		this.locationsRepository = locationsRepository;
		this.configuration = configuration;
	}

	[HttpGet("{latitude}/{longitude}")]
	[Authorize]
	public async Task<IActionResult> GetServerUrl(double latitude, double longitude)
	{
		if (latitude < -90 || latitude > 90) return BadRequest();
		if (longitude < -180 || latitude > 180) return BadRequest();

		int precision;
		int defaultServerId;
        try{
            precision = Int32.Parse(configuration["GeoHasher:Precision"]);
            defaultServerId = Int32.Parse(configuration["Servers:DefaultServerId"]);
        }
        catch (ArgumentNullException e){
            throw new ArgumentNullException("Precision value is missing from configuration.", e);
        }

        var geohasher = new Geohasher();
        string geohashCode = geohasher.Encode(latitude, longitude, precision);

		IEnumerable<Location> locations = await locationsRepository.GetAllAsync();
		Location? location = locations.FirstOrDefault(l => geohashCode.StartsWith(l.GeoHashCode));
		
		long serverId;
		if (location == null) serverId = defaultServerId;
		else serverId = location.ServerId;

        Server? server = await serversRepository.GetAsync(serverId);
		if (server == null) return StatusCode(StatusCodes.Status500InternalServerError);
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

using GeoChat.Geolocation.Api.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace GeoChat.Geolocation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationController : ControllerBase
{
	public LocationController()
	{
	}

	[HttpGet("{latitude}/{longitude}")]
	[Authorize]
	public async Task<IActionResult> GetServerUrl(double latitude, double longitude)
	{
		throw new NotImplementedException();
	}

	[HttpPost]
	[Authorize]
	public async Task<IActionResult> CreateServerLocation(LocationCreateDto location)
	{
		throw new NotImplementedException();
	}

	[HttpDelete("{locationId}")]
	[Authorize]
	public async Task<IActionResult> DeleteServerLocation(int locationId)
	{
		throw new NotImplementedException();
	}

}

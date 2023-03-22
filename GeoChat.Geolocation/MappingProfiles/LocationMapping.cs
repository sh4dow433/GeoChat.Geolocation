using AutoMapper;
using GeoChat.Geolocation.Api.Dtos;
using GeoChat.Geolocation.Api.Entities;

namespace GeoChat.Geolocation.Api.MappingProfiles;

public class LocationMapping : Profile
{
	public LocationMapping()
	{
		CreateMap<LocationCreateDto, Location>();
		CreateMap<Location, LocationResponseDto>();
	}
}

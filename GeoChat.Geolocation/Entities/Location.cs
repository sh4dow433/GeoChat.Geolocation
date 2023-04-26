namespace GeoChat.Geolocation.Api.Entities;

public class Location
{
    public long Id { get; set; }
    public string GeoHashCode { get; set; }
    public long ServerId { get; set; }
}

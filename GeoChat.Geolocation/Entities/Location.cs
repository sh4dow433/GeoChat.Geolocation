namespace GeoChat.Geolocation.Api.Entities;

public class Location
{
    public long id { get; set; }
    public String geoHashCode { get; set; }
    public long serverId { get; set; }
    
    public Location(int id, String geoHashCode, long serverId) { 
        this.id = id;
        this.geoHashCode = geoHashCode;
        this.serverId = serverId;
    }
}

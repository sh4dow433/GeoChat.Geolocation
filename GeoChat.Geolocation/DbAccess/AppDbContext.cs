using GeoChat.Geolocation.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeoChat.Geolocation.Api.DbAccess;

public class AppDbContext : DbContext
{
    public virtual DbSet<Server> Servers => Set<Server>();
    public virtual DbSet<Location> Locations => Set<Location>();

    IConfiguration configuration;

    public AppDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        this.configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        int defaultServerId;
        try
        {
            defaultServerId = Int32.Parse(configuration["Servers:DefaultServerId"]);
        }
        catch (ArgumentNullException e)
        {
            throw new ArgumentNullException("Precision value is missing from configuration.", e);
        }

        modelBuilder.Entity<Server>().HasData(
            new Server() { Id = defaultServerId, Name = "Default", Url = "https://geochatdefaultchat.azurewebsites.net/" },
            new Server() { Id = 1, Name = "Timis", Url = "https://geochattimisoarachat.azurewebsites.net/" }
            //new Server() { Id = 2, Name = "Bucuresti", Url = ""},
            //new Server() { Id = 3, Name = "Cluj-Napoca", Url = ""}
        );

        modelBuilder.Entity<Location>().HasData(
            new Location() { Id = 1, GeoHashCode = "u2ph8", ServerId = 1 },
            new Location() { Id = 2, GeoHashCode = "u2ph9", ServerId = 1 },
            new Location() { Id = 3, GeoHashCode = "u2phd", ServerId = 1 },
            new Location() { Id = 4, GeoHashCode = "u2phe", ServerId = 1 },
            new Location() { Id = 5, GeoHashCode = "u2phs", ServerId = 1 },
            new Location() { Id = 6, GeoHashCode = "u2pht", ServerId = 1 },
            new Location() { Id = 7, GeoHashCode = "u2ph2", ServerId = 1 },
            new Location() { Id = 8, GeoHashCode = "u2ph3", ServerId = 1 },
            new Location() { Id = 9, GeoHashCode = "u2ph6", ServerId = 1 },
            new Location() { Id = 10, GeoHashCode = "u2ph7", ServerId = 1 },
            new Location() { Id = 11, GeoHashCode = "u2phk", ServerId = 1 },
            new Location() { Id = 12, GeoHashCode = "u2phm", ServerId = 1 },
            new Location() { Id = 13, GeoHashCode = "u2ph0", ServerId = 1 },
            new Location() { Id = 14, GeoHashCode = "u2ph1", ServerId = 1 },
            new Location() { Id = 15, GeoHashCode = "u2ph4", ServerId = 1 },
            new Location() { Id = 16, GeoHashCode = "u2ph5", ServerId = 1 },
            new Location() { Id = 17, GeoHashCode = "u2phh", ServerId = 1 },
            new Location() { Id = 18, GeoHashCode = "u2phj", ServerId = 1 }

            //new Location() { Id = 19, GeoHashCode = "sxfsb", ServerId = 2 },
            //new Location() { Id = 20, GeoHashCode = "sxfsc", ServerId = 2 },
            //new Location() { Id = 21, GeoHashCode = "sxfsf", ServerId = 2 },
            //new Location() { Id = 22, GeoHashCode = "sxfsg", ServerId = 2 },
            //new Location() { Id = 23, GeoHashCode = "sxfsu", ServerId = 2 },
            //new Location() { Id = 24, GeoHashCode = "sxfs8", ServerId = 2 },
            //new Location() { Id = 25, GeoHashCode = "sxfs9", ServerId = 2 },
            //new Location() { Id = 26, GeoHashCode = "sxfsd", ServerId = 2 },
            //new Location() { Id = 27, GeoHashCode = "sxfse", ServerId = 2 },
            //new Location() { Id = 28, GeoHashCode = "sxfss", ServerId = 2 },
            //new Location() { Id = 29, GeoHashCode = "sxfs2", ServerId = 2 },
            //new Location() { Id = 30, GeoHashCode = "sxfs3", ServerId = 2 },
            //new Location() { Id = 31, GeoHashCode = "sxfs6", ServerId = 2 },
            //new Location() { Id = 32, GeoHashCode = "sxfs7", ServerId = 2 },
            //new Location() { Id = 33, GeoHashCode = "sxfsk", ServerId = 2 },
            //new Location() { Id = 34, GeoHashCode = "sxfxz", ServerId = 2 },
            //new Location() { Id = 35, GeoHashCode = "sxfxx", ServerId = 2 },
            //new Location() { Id = 36, GeoHashCode = "sxfmp", ServerId = 2 },
            //new Location() { Id = 37, GeoHashCode = "sxft3", ServerId = 2 },
            //new Location() { Id = 38, GeoHashCode = "sxft6", ServerId = 2 },
            //new Location() { Id = 39, GeoHashCode = "sxft0", ServerId = 2 },
            //new Location() { Id = 40, GeoHashCode = "sxft1", ServerId = 2 },
            //new Location() { Id = 41, GeoHashCode = "sxft4", ServerId = 2 },
            //new Location() { Id = 42, GeoHashCode = "sxft5", ServerId = 2 },
            //new Location() { Id = 43, GeoHashCode = "sxfth", ServerId = 2 },

            //new Location() { Id = 44, GeoHashCode = "u82f0", ServerId = 3 },
            //new Location() { Id = 45, GeoHashCode = "u82f1", ServerId = 3 },
            //new Location() { Id = 46, GeoHashCode = "u82f4", ServerId = 3 },
            //new Location() { Id = 47, GeoHashCode = "u82f5", ServerId = 3 },
            //new Location() { Id = 48, GeoHashCode = "u82fh", ServerId = 3 },
            //new Location() { Id = 49, GeoHashCode = "u82fk", ServerId = 3 },
            //new Location() { Id = 50, GeoHashCode = "u82cb", ServerId = 3 },
            //new Location() { Id = 51, GeoHashCode = "u82cc", ServerId = 3 },
            //new Location() { Id = 52, GeoHashCode = "u82cf", ServerId = 3 },
            //new Location() { Id = 53, GeoHashCode = "u829u", ServerId = 3 },
            //new Location() { Id = 54, GeoHashCode = "u829v", ServerId = 3 },
            //new Location() { Id = 55, GeoHashCode = "u829y", ServerId = 3 },
            //new Location() { Id = 56, GeoHashCode = "u829z", ServerId = 3 },
            //new Location() { Id = 57, GeoHashCode = "u82dp", ServerId = 3 }
        );
    }
}

using GeoChat.Geolocation.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GeoChat.Geolocation.Api.DbAccess;

public class AppDbContext : DbContext
{
    public virtual DbSet<Server> Servers => Set<Server>();
    public virtual DbSet<Location> Locations => Set<Location>();

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); 
    }

}

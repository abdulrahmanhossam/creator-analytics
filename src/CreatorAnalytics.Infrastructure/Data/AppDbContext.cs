using CreatorAnalytics.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CreatorAnalytics.Infrastructure.Data;

public class AppDbContext : DbContext
{
    // This allows ASP.NET Core to inject the SQL Server connection string
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Creator> Creators { get; set; }
    public DbSet<Channel> Channels { get; set; }
    public DbSet<Video> Videos { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<VideoAnalytic> VideoAnalytics { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}
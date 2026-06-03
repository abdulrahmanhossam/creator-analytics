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

        // 1. Creator -> Channel (One-to-Many)
        modelBuilder.Entity<Channel>()
             .HasOne(channel => channel.Creator)
             .WithMany(creator => creator.Channels)
             .HasForeignKey(channel => channel.CreatorId);

        // 2. Channel -> Video (One-to-Many)
        modelBuilder.Entity<Video>()
             .HasOne(video => video.Channel)
             .WithMany(channel => channel.Videos)
             .HasForeignKey(video => video.ChannelId);

        // 3. Video -> VideoAnalytic (One-to-Many)
        modelBuilder.Entity<VideoAnalytic>()
            .HasOne(analytic => analytic.Video)
            .WithMany(video => video.VideoAnalytics)
            .HasForeignKey(analytic => analytic.VideoId);

        // 4. Video -> Tag (Many-to-Many)
        modelBuilder.Entity<Video>()
            .HasMany(video => video.Tags)
            .WithMany(tag => tag.Videos);
    }

}
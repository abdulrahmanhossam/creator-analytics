namespace CreatorAnalytics.Core.Entities;

public class Video
{
    public Guid Id { get; set; }
    public Guid ChannelId { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime PublishedAt { get; set; }
    public TimeSpan Duration { get; set; }

    // Navigation prop: A video can have many video and tags analytics and one channel
    public Channel Channel { get; set; } = null!;
    public ICollection<VideoAnalytic> VideoAnalytics { get; set; } = new List<VideoAnalytic>();
    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
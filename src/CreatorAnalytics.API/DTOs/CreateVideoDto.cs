namespace CreatorAnalytics.API.DTOs;

public class CreateVideoDto
{
    public Guid ChannelId { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime PublishedAt { get; set; }
    public TimeSpan Duration { get; set; }
}
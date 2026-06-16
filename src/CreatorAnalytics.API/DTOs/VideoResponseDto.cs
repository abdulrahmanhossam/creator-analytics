namespace CreatorAnalytics.API.DTOs;

public class VideoResponseDto
{
    public Guid Id { get; set; }
    public Guid ChannelId { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime PublishedAt { get; set; }
    public TimeSpan Duration { get; set; }
}
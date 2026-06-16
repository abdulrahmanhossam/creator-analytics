namespace CreatorAnalytics.API.DTOs;

// Used when the client is sending data to create a channel
public class CreateChannelDto
{
    public Guid CreatorId { get; set; }
    public string Platform { get; set; } = string.Empty;
    public string ChannelName { get; set; } = string.Empty;
    public string ExternalId { get; set; } = string.Empty;
}
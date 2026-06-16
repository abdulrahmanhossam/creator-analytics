namespace CreatorAnalytics.API.DTOs;

// Used when the API is returning data to the client
public class ChannelResponseDto
{
    public Guid Id { get; set; }
    public string Platform { get; set; } = string.Empty;
    public string ChannelName { get; set; } = string.Empty;
}
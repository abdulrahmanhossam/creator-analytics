namespace CreatorAnalytics.Core.Entities;

public class Channel
{
    public Guid Id { get; set; }
    public Guid CreatorId { get; set; }
    public string Platform { get; set; } = string.Empty;
    public string ChannelName { get; set; } = string.Empty;
    public string ExternalId { get; set; } = string.Empty;

    // Navigation prop: A channel can contain many videos and one creator
    public Creator Creator { get; set; } = null!;
    public ICollection<Video> Videos { get; set; } = new List<Video>();
}
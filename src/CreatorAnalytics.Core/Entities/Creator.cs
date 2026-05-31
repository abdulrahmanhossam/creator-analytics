namespace CreatorAnalytics.Core.Entities;

public class Creator
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime CreateAt { get; set; } = DateTime.Now;

    // Navigation prop: A creator can have many channels
    public ICollection<Channel> Channels { get; set; } = new List<Channel>();
}
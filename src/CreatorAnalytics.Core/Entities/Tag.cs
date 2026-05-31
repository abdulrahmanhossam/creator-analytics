namespace CreatorAnalytics.Core.Entities;

public class Tag
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Video> Videos = new List<Video>();
}
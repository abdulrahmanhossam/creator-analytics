namespace CreatorAnalytics.Core.Models;

public class ChannelPerformanceReport
{
    public Guid ChannelId { get; set; }
    public long TotalViews { get; set; }
    public long TotalLikes { get; set; }
    public long TotalComments { get; set; }
}
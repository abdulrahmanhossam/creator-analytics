namespace CreatorAnalytics.Core.Entities;

public class VideoAnalytic
{
    public Guid Id { get; set; }
    public Guid VideoId { get; set; }
    public DateTime RecordedAt { get; set; }
    public long ViewCount { get; set; }
    public long LikeCount { get; set; }
    public long CommentCount { get; set; }
    public double AverageViewDurationSeconds { get; set; }

    // Nav prop: video analytic can relate to one video
    public Video Video { get; set; } = null!;
}
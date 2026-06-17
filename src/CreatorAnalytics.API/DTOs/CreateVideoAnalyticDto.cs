namespace CreatorAnalytics.API.DTOs;

public class CreateVideoAnalyticDto
{
    public DateTime RecordedAt { get; set; }
    public long ViewCount { get; set; }
    public long LikeCount { get; set; }
    public long CommentCount { get; set; }
    public double AverageViewDurationSeconds { get; set; }
}
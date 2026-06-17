using CreatorAnalytics.Core.Entities;
using CreatorAnalytics.Core.Interfaces;
using CreatorAnalytics.Core.Models;
using CreatorAnalytics.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CreatorAnalytics.Infrastructure.Repositories;

public class VideoAnalyticRepository : IVideoAnalyticRepository
{
    private readonly AppDbContext _dbContext;

    public VideoAnalyticRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(VideoAnalytic analytic)
    {
        await _dbContext.VideoAnalytics.AddAsync(analytic);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<ChannelPerformanceReport> GetPerformanceAsync(Guid channelId)
    {
        var report = await _dbContext.VideoAnalytics
            // Filter down to only this channel's data
            .Where(x => x.Video.ChannelId == channelId)
            // Group all those rows together by the ChannelId
            .GroupBy(x => x.Video.ChannelId)
            // Project the grouped data into our plain C# Model
            .Select(group => new ChannelPerformanceReport
            {
                ChannelId = group.Key, // The Key is the ChannelId we grouped by
                TotalViews = group.Sum(x => x.ViewCount),
                TotalLikes = group.Sum(x => x.LikeCount),
                TotalComments = group.Sum(x => x.CommentCount)
            })
            .FirstOrDefaultAsync();

        //  Safety Net: If the channel exists but has ZERO analytics yet, 
        // we shouldn't return null. We should return a report with 0s.
        return report ?? new ChannelPerformanceReport
        {
            ChannelId = channelId,
            TotalViews = 0,
            TotalLikes = 0,
            TotalComments = 0
        };
    }
}
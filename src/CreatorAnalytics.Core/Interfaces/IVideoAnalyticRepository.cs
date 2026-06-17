using CreatorAnalytics.Core.Entities;
using CreatorAnalytics.Core.Models;

namespace CreatorAnalytics.Core.Interfaces;

public interface IVideoAnalyticRepository
{
    Task AddAsync(VideoAnalytic analytic);
    Task<ChannelPerformanceReport> GetPerformanceAsync(Guid channelId);
}
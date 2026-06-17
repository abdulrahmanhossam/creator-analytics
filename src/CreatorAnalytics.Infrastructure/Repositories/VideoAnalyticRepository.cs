using CreatorAnalytics.Core.Entities;
using CreatorAnalytics.Core.Interfaces;
using CreatorAnalytics.Infrastructure.Data;

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
}
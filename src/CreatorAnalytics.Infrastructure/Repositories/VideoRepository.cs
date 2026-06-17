using CreatorAnalytics.Core.Entities;
using CreatorAnalytics.Core.Interfaces;
using CreatorAnalytics.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CreatorAnalytics.Infrastructure.Repositories;

public class VideoRepository : IVideoRepository
{
    private readonly AppDbContext _dbContext;
    public VideoRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Video>> GetAllByCreatorIdAsync(Guid channelId)
    {
        return await _dbContext.Videos
            .Include(x => x.Tags)
            .Include(x => x.Channel)
            .Where(x => x.ChannelId == channelId).ToListAsync();
    }

    public async Task<Video?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Videos
            .Include(x => x.Tags)
            .Include(x => x.Channel)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(Video video)
    {
        _dbContext.Videos.Update(video);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(Video video)
    {
        await _dbContext.Videos.AddAsync(video);
        await _dbContext.SaveChangesAsync();

    }

    public async Task DeleteAsync(Video video)
    {
        _dbContext.Videos.Remove(video);
        await _dbContext.SaveChangesAsync();
    }
}
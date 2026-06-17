using CreatorAnalytics.Core.Entities;
using CreatorAnalytics.Core.Interfaces;
using CreatorAnalytics.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CreatorAnalytics.Infrastructure.Repositories;

public class ChannelRepository : IChannelRepository
{
    private readonly AppDbContext _dbContext;
    public ChannelRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Channel>> GetAllByCreatorIdAsync(Guid creatorId)
    {
        return await _dbContext.Channels
            .Where(x => x.CreatorId == creatorId)
            .ToListAsync();
    }

    public async Task<Channel?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Channels.FindAsync(id);
    }

    public async Task UpdateAsync(Channel channel)
    {
        // EF Core knows to look at the Id property and delete that specific row
        _dbContext.Channels.Update(channel);
        await _dbContext.SaveChangesAsync();
    }
    public async Task AddAsync(Channel channel)
    {
        await _dbContext.Channels.AddAsync(channel);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Channel channel)
    {
        // EF Core knows to look at the Id property and delete that specific row
        _dbContext.Channels.Remove(channel);
        await _dbContext.SaveChangesAsync();
    }
}
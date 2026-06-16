using CreatorAnalytics.Core.Entities;

namespace CreatorAnalytics.Core.Interfaces;

public interface IVideoRepository
{
    Task<Video?> GetByIdAsync(Guid id);
    Task<IEnumerable<Video>> GetAllByCreatorIdAsync(Guid channelId);
    Task AddAsync(Video video);
    Task UpdateAsync(Video video);
    Task DeleteAsync(Video video);
}
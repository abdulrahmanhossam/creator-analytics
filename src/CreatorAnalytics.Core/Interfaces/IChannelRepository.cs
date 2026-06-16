
using CreatorAnalytics.Core.Entities;

namespace CreatorAnalytics.Core.Interfaces;

public interface IChannelRepository
{
    Task<Channel?> GetByIdAsync(Guid id);
    Task<IEnumerable<Channel>> GetAllByCreatorIdAsync(Guid creatorId);
    Task AddAsync(Channel channel);
    Task UpdateAsync(Channel channel);
    Task DeleteAsync(Channel channel);
}
using CreatorAnalytics.Core.Entities;

namespace CreatorAnalytics.Core.Interfaces;

public interface IVideoAnalyticRepository
{
    Task AddAsync(VideoAnalytic analytic);

}
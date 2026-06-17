using CreatorAnalytics.API.DTOs;
using CreatorAnalytics.Core.Entities;
using CreatorAnalytics.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CreatorAnalytics.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VideosController : ControllerBase
{
    private readonly IVideoRepository _videoRepository;
    private readonly IVideoAnalyticRepository _analyticRepository;

    public VideosController(IVideoRepository videoRepository, IVideoAnalyticRepository analyticRepository)
    {
        _videoRepository = videoRepository;
        _analyticRepository = analyticRepository;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetVideo(Guid id)
    {
        // 1. Fetch the video from the repository
        // 2. Check if it's null -> return NotFound()
        // 3. Map the Entity to a VideoResponseDto
        // 4. Return Ok(responseDto)

        var video = await _videoRepository
            .GetByIdAsync(id);

        if (video == null)
            return NotFound();

        var responseDto = new VideoResponseDto
        {
            Id = video.Id,
            ChannelId = video.ChannelId,
            Title = video.Title,
            PublishedAt = video.PublishedAt,
            Duration = video.Duration
        };

        return Ok(responseDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateVideo([FromBody] CreateVideoDto videoDto)
    {
        // 1. Map the CreateVideoDto to a new Video Entity
        // 2. Pass it to the repository to AddAsync
        // 3. Map the saved Entity to a VideoResponseDto
        // 4. Return CreatedAtAction pointing to GetVideo

        var newVideo = new Video
        {
            ChannelId = videoDto.ChannelId,
            Title = videoDto.Title,
            PublishedAt = videoDto.PublishedAt,
            Duration = videoDto.Duration
        };

        await _videoRepository.AddAsync(newVideo);

        var responseDto = new VideoResponseDto
        {
            Id = newVideo.Id,
            ChannelId = newVideo.ChannelId,
            Title = newVideo.Title,
            PublishedAt = newVideo.PublishedAt,
            Duration = newVideo.Duration
        };

        return CreatedAtAction(nameof(GetVideo), new { id = responseDto.Id }, responseDto);
    }


    [HttpPost("{videoId:guid}/analytics")]
    public async Task<IActionResult> AddAnalytics(Guid videoId, [FromBody] CreateVideoAnalyticDto analyticDto)
    {
        var newAnalytics = new VideoAnalytic
        {
            VideoId = videoId,
            RecordedAt = analyticDto.RecordedAt,
            ViewCount = analyticDto.ViewCount,
            LikeCount = analyticDto.LikeCount,
            CommentCount = analyticDto.CommentCount,
            AverageViewDurationSeconds = analyticDto.AverageViewDurationSeconds
        };

        await _analyticRepository.AddAsync(newAnalytics);

        return Created();
    }
}
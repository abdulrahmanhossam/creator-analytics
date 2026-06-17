using CreatorAnalytics.API.DTOs;
using CreatorAnalytics.Core.Entities;
using CreatorAnalytics.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CreatorAnalytics.API.Controllers;

[ApiController] // Tells ASP.NET this class handles web requests
[Route("api/[controller]")] // Automatically routes to /api/channels
public class ChannelsController : ControllerBase
{
    private readonly IChannelRepository _channelRepository;
    private readonly IVideoAnalyticRepository _analyticRepository;

    public ChannelsController(IChannelRepository channelRepository, IVideoAnalyticRepository analyticRepository)
    {
        _channelRepository = channelRepository;
        _analyticRepository = analyticRepository;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetChannel(Guid id)
    {
        var channel = await _channelRepository.GetByIdAsync(id);

        if (channel == null)
            return NotFound();

        var responseDto = new ChannelResponseDto
        {
            Id = channel.Id,
            ChannelName = channel.ChannelName,
            Platform = channel.Platform
        };

        return Ok(responseDto);
    }

    [HttpGet("{channelId:guid}/performance")]
    public async Task<IActionResult> GetChannelPerformance(Guid channelId)
    {
        var channel = await _channelRepository.GetByIdAsync(channelId);
        if (channel == null)
        {
            return NotFound("Channel not found.");
        }

        var performanceReport = await _analyticRepository.GetPerformanceAsync(channelId);

        return Ok(performanceReport);
    }

    [HttpPost]
    public async Task<IActionResult> CreateChannel([FromBody] CreateChannelDto channelDto)
    {
        // 2. Map the DTO to the real Entity for the database
        var newChannel = new Channel
        {
            CreatorId = channelDto.CreatorId,
            Platform = channelDto.Platform,
            ChannelName = channelDto.ChannelName,
            ExternalId = channelDto.ExternalId
        };

        // Save it to the database (Entity Framework will automatically generate the new Id)
        await _channelRepository.AddAsync(newChannel);

        var responseDto = new ChannelResponseDto
        {
            Id = newChannel.Id,
            ChannelName = newChannel.ChannelName,
            Platform = newChannel.Platform
        };


        // 3. The RESTful Response
        // This tells the client: "Success (201)! Here is the object, and you can find it at GetChannel using this ID."
        return CreatedAtAction(nameof(GetChannel), new { id = responseDto.Id }, responseDto);
    }
}
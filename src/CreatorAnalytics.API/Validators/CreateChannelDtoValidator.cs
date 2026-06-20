using CreatorAnalytics.API.DTOs;
using FluentValidation;

namespace CreatorAnalytics.API.Validators;

// Inherit from AbstractValidator and pass in the DTO you want to protect
public class CreateChannelDtoValidator : AbstractValidator<CreateChannelDto>
{
    public CreateChannelDtoValidator()
    {
        // Rule 1: CreatorId cannot be an empty GUID
        RuleFor(c => c.CreatorId)
            .NotEmpty().WithMessage("A valid Creator ID is required.");

        // Rule 2: Channel Name must exist and cannot be insanely long
        RuleFor(c => c.ChannelName)
            .NotEmpty().WithMessage("Channel Name cannot be blank.")
            .MaximumLength(100).WithMessage("Channel Name must be under 100 characters.");

        // Rule 3: We only support specific platforms
        RuleFor(channel => channel.Platform)
            .NotEmpty()
            .Must(BeAValidPlatform).WithMessage("Platform must be 'YouTube', 'Twitch', or 'TikTok'.");
    }

    // A custom helper method for Rule 3
    private bool BeAValidPlatform(string platform)
    {
        var validPlatforms = new[] { "YouTube", "Twitch", "TikTok" };
        return validPlatforms.Contains(platform);
    }
}
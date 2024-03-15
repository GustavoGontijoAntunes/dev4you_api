using app.Domain.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace app.WebApi.Dtos.Requests
{
    public class ProfilePost
    {
        public long? Id { get; set; }
        public string? Name { get; set; }
    }

    public class ProfilePostValidator : AbstractValidator<ProfilePost>
    {
        public ProfilePostValidator(IStringLocalizer<CustomMessages> localizer)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizer[CustomMessages.NameIsRequiredToCreateProfile].Value)
                .MaximumLength(50).WithMessage(localizer[CustomMessages.ProfileNameMaxLength].Value);
        }
    }
}
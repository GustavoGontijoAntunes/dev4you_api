using app.Domain.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace app.WebApi.Dtos.Requests
{
    public class PermissionPost
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class PermissionPostValidator : AbstractValidator<PermissionPost>
    {
        public PermissionPostValidator(IStringLocalizer<CustomMessages> localizer)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizer[CustomMessages.NameIsRequiredToCreatePermission].Value)
                .MaximumLength(50).WithMessage(localizer[CustomMessages.PermissionNameMaxLength].Value);

            RuleFor(x => x.Description).NotEmpty().WithMessage(localizer[CustomMessages.DescriptionIsRequiredToCreatePermission].Value)
                .MaximumLength(200).WithMessage(localizer[CustomMessages.PermissionDescriptionMaxLength].Value);
        }
    }
}
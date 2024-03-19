using app.Domain.Models.Base;
using app.Domain.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace app.Domain.Models
{
    public class Permission : BaseModel
    {
        public Permission() { }

        public string Name { get; set; }
        public string Description { get; set; }
        public List<Profile> Profiles { get; set; }
    }

    public class PermissionPostValidator : AbstractValidator<Permission>
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
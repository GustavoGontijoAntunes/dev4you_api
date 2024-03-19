using app.Domain.Models.Authentication;
using app.Domain.Models.Base;
using app.Domain.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace app.Domain.Models
{
    public class Profile : BaseModel
    {
        public Profile() { }

        public string Name { get; set; }
        public List<Permission> Permissions { get; set; }
        public virtual List<long> PermissionsIds { get; set; }
        public List<User> Users { get; set; }
    }

    public class ProfilePostValidator : AbstractValidator<Profile>
    {
        public ProfilePostValidator(IStringLocalizer<CustomMessages> localizer)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizer[CustomMessages.NameIsRequiredToCreateProfile].Value)
                .MaximumLength(50).WithMessage(localizer[CustomMessages.ProfileNameMaxLength].Value);
        }
    }
}
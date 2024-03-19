using app.Domain.Models.Base;
using app.Domain.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System.Collections;

namespace app.Domain.Models.Authentication
{
    public class User : BaseModel
    {
        public User() { }

        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual string NewPassword { get; set; }
        public virtual string? Token { get; set; }
        public string? SessionId { get; set; }
        public long ProfileId { get; set; }
        public virtual IEnumerable Permissions { get; set; }
        public Profile Profile { get; set; }
    }

    public class UserPostValidator : AbstractValidator<User>
    {
        public UserPostValidator(IStringLocalizer<CustomMessages> localizer)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizer[CustomMessages.NameIsRequiredToCreateUser].Value)
                .MaximumLength(100).WithMessage(localizer[CustomMessages.UserNameMaxLength].Value);

            RuleFor(x => x.Login).NotEmpty().WithMessage(localizer[CustomMessages.LoginIsRequiredToCreateUser].Value)
                .MaximumLength(20).WithMessage(localizer[CustomMessages.UserLoginMaxLength].Value);

            RuleFor(x => x.Password).NotEmpty().WithMessage(localizer[CustomMessages.PasswordIsRequiredToCreateUser].Value);

            RuleFor(x => x.ProfileId).NotEmpty().WithMessage(localizer[CustomMessages.ProfileIsRequiredToCreateUser].Value);
        }
    }
}
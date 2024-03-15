using app.Domain.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace app.WebApi.Dtos.Requests
{
    public class UserLogin
    {
        public string? Login { get; set; }
        public string? Password { get; set; }
    }

    public class UserLoginValidator : AbstractValidator<UserLogin>
    {
        public UserLoginValidator(IStringLocalizer<CustomMessages> localizer)
        {
            RuleFor(x => x.Login).NotEmpty().WithMessage(localizer[CustomMessages.LoginIsRequiredToLogin].Value);
            RuleFor(x => x.Password).NotEmpty().WithMessage(localizer[CustomMessages.PasswordIsRequiredToLogin].Value);
        }
    }
}
using app.Domain.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace app.WebApi.Dtos.Requests
{
    public class UserPasswordPut
    {
        public long? Id { get; set; }
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
    }

    public class UserPasswordPutValidator : AbstractValidator<UserPasswordPut>
    {
        public UserPasswordPutValidator(IStringLocalizer<CustomMessages> localizer)
        {
            RuleFor(x => x.OldPassword).NotEmpty().WithMessage(localizer[CustomMessages.OldPasswordIsRequiredToChangeUserPassword].Value);
            RuleFor(x => x.NewPassword).NotEmpty().WithMessage(localizer[CustomMessages.NewPasswordIsRequiredToChangeUserPassword].Value);
        }
    }
}
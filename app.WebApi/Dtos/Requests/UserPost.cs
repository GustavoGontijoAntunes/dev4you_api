using app.Domain.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace app.WebApi.Dtos.Requests
{
    public class UserPost
    {
        public string? Name { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public long? ProfileId { get; set; }
        //public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }

    public class UserPostValidator : AbstractValidator<UserPost>
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
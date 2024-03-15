using app.Domain.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace app.WebApi.Dtos.Requests
{
    public class UserGet : Filter
    {
        /// <summary>
        /// User name
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// User login
        /// </summary>
        public string? Login { get; set; }

        /// <summary>
        /// User profile id
        /// </summary>
        public long? ProfileId { get; set; }
    }

    public class UserGetValidator : AbstractValidator<UserGet>
    {
        public UserGetValidator(IStringLocalizer<CustomMessages> localizer)
        {

        }
    }
}
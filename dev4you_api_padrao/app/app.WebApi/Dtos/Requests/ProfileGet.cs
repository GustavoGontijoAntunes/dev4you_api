using app.Domain.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace app.WebApi.Dtos.Requests
{
    public class ProfileGet : Filter
    {
        /// <summary>
        /// Profile name
        /// </summary>
        public string? Name { get; set; }
    }

    public class ProfileGetValidator : AbstractValidator<ProfileGet>
    {
        public ProfileGetValidator(IStringLocalizer<CustomMessages> localizer)
        {

        }
    }
}
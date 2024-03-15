using app.Domain.Extensions;
using FluentValidation;

namespace app.Domain.Models.Filters
{
    public class ProfileSearch : PagedSearch
    {
        public string? Name { get; set; }

        protected override bool IsValid()
        {
            ValidationResult = new ProfileSearchValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class ProfileSearchValidation : AbstractValidator<ProfileSearch>
    {
        public ProfileSearchValidation()
        {

        }
    }
}
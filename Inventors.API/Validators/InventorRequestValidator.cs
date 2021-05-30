using FluentValidation;
using Inventors.API.Contracts.V1.Requests;

namespace Inventors.API.Validators
{
    public class InventorRequestValidator : AbstractValidator<InventorRequest>
    {
        public InventorRequestValidator()
        {
            RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(50);

            RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(50);
        }
    }
}

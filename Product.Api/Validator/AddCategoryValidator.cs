using FluentValidation;
using Product.Application.Features.Command;

namespace Product.Api.Validator
{
    public class AddCategoryValidator : AbstractValidator<AddCategoryCommand>
    {
        public AddCategoryValidator()
        {
            RuleFor(x => x.Name).NotNull().MinimumLength(3);
            RuleFor(x => x.MinimumStock).NotNull().InclusiveBetween(0, int.MaxValue);
        }
    }
}

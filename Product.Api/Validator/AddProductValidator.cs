using FluentValidation;
using Product.Application.Features.Command;

namespace Product.Api.Validator
{
    public class AddProductValidator : AbstractValidator<AddProductCommand>
    {
        public AddProductValidator()
        {
            RuleFor(x => x.Price).NotNull().InclusiveBetween(1, int.MaxValue);
            RuleFor(x => x.Title).NotNull().MinimumLength(200);
            RuleFor(x => x.Description).NotNull();
            RuleFor(x => x.CategoryId).NotNull();
            RuleFor(x => x.Stock).NotNull().InclusiveBetween(0, int.MaxValue);
        }
    }
}

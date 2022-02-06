using FluentValidation;
using Restaurant.Models.Requests;

namespace Restaurant.Host.Validators
{
    public class ProductRequestValidator : AbstractValidator<ProductRequest>
    {
        public ProductRequestValidator()
        {
            RuleFor(x => x.Price).NotEmpty().NotNull();
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }
    }
}

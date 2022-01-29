using FluentValidation;
using Restaurant.Models.Requests;

namespace Restaurant.Host.Validators
{
    public class OrderRequestValidator : AbstractValidator<OrderRequest>
    {
        public OrderRequestValidator()
        {
            RuleFor(x => x.CreatedOn).NotEmpty().NotNull();
            RuleFor(x => x.TotalPrice).NotNull().NotEmpty();
            RuleFor(x => x.Products).NotNull().NotEmpty();
        }
    }
}

using FluentValidation;
using Restaurant.Models.Requests;

namespace Restaurant.Host.Validators
{
    public class TableRequestValidator : AbstractValidator<TableRequest>
    {
        public TableRequestValidator()
        {
            RuleFor(x => x.Orders).NotEmpty().NotNull();
        }
    }
}

using FluentValidation;

namespace ExampleProject.Models.Validators
{
	public class ProductValidator: AbstractValidator<Product>
	{
        public ProductValidator()
        {
            RuleFor(x => x.Email).NotNull().WithMessage("The email filed must not be empty");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Please, enter an correct email address");
            RuleFor(x => x.ProductName).NotNull().NotEmpty().WithMessage("Please, fill in the gap");
            RuleFor(x => x.ProductName).MaximumLength(100).WithMessage("Please, don't enter more than 100 character");
        }
    }
}

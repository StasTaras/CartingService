using CartingService.RequestModels;
using FluentValidation;

namespace CartingService.Validators
{
    public class AddCartItemRequestValidator : AbstractValidator<AddCartItemRequest>
    {
        public AddCartItemRequestValidator()
        {
            RuleFor(r => r.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(r => r.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(r => r.Price).NotEmpty().WithMessage("Price is required")
                .GreaterThan(0).WithMessage("Price must be greater than 0");
            RuleFor(r => r.ImageUrl).NotEmpty().When(r => !string.IsNullOrEmpty(r.AltText))
                .WithMessage("Image URL is required when alt text is provided");
            RuleFor(r => r.Quantity).NotEmpty().WithMessage("Quantity is required")
                .GreaterThan(0).WithMessage("Quantity must be greater than 0");
        }
    }
}
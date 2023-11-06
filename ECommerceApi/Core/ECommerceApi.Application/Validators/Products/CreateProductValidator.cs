using FluentValidation;

public class CreateProductValidator : AbstractValidator<ViewModelCreateProduct>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name)
        .NotEmpty()
        .NotNull()
        .WithMessage("Name is required")
        .MaximumLength(50).WithMessage("Name must be less than 50 characters");

        RuleFor(x => x.Price)
        .NotEmpty()
        .NotNull()
        .WithMessage("Price is required")
        .Must(x => x >= 0).WithMessage("Price must be 0 or greater than 0");

        RuleFor(x => x.Stock)
        .NotEmpty()
        .NotNull()
        .WithMessage("Stock is required")
        .Must(x => x >= 0).WithMessage("Stock must be 0 or greater than 0");
    }
}
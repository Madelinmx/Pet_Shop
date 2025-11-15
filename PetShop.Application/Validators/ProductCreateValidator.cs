using FluentValidation;
using PetShop.Application.Dtos.Product;

namespace PetShop.Application.Validators
{
    public class ProductCreateValidator : AbstractValidator<ProductCreateDto>
    {
        public ProductCreateValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("El nombre no puede estar vacío.")
                .MinimumLength(3).WithMessage("El nombre debe tener al menos 3 caracteres.");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("El precio debe ser mayor a cero.");

            RuleFor(p => p.CategoryId)
                .GreaterThan(0).WithMessage("La categoría es requerida.");
        }
    }
}
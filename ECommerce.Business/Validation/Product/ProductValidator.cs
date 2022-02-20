using ECommerce.Business.Models;
using ECommerce.Core.Entities;
using FluentValidation;

namespace ECommerce.Api.Validation
{
    public class ProductValidator : AbstractValidator<SaveProductDTO>
    {
        public ProductValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("Name alanı boş olamaz");
        }
    }
}

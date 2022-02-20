using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Business.Models;
using ECommerce.Core.Entities;
using FluentValidation;


namespace ECommerce.Application.Validation
{
    public class CategoryValidator : AbstractValidator<SaveCategoryDTO>
    {
        public CategoryValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("Name alanı boş olamaz");
        }
    }
}

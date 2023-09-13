using CoffeeShop.Application.UseCases.DTO;
using CoffeeShop.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Implementation.Validators
{
    public class CreateIngredientValidator : AbstractValidator<IngredientDto>
    {
        private Context _context;

        public CreateIngredientValidator(Context context)
        {
            _context = context;
            RuleFor(x => x.IngredientName).Cascade(CascadeMode.Stop)
                                .NotEmpty().WithMessage("Name is required")
                                .MinimumLength(3).WithMessage("Ingredient name requires minimum 3 characters")
                                .Must(NameNotInUse).WithMessage("Ingredient {PropertyValue} already exist");
        }

        private bool NameNotInUse(string name)
        {
            var exists = _context.Ingredients.Any(x => x.IngredientName == name);

            return !exists;
        }
    }
}

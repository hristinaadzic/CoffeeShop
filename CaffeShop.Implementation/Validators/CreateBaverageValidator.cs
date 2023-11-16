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
    public class CreateBaverageValidator : AbstractValidator<CreateBaverageDto>
    {
        private Context _context;

        public CreateBaverageValidator(Context context)
        {
            _context = context;

            RuleFor(x => x.BaverageName).Cascade(CascadeMode.Stop)
                                .NotEmpty().WithMessage("Name is required")
                                .MinimumLength(3).WithMessage("Name must contain at least 3 charachters");

            RuleFor(x => x.CategoryId).Cascade(CascadeMode.Stop)
                                       .NotEmpty().WithMessage("CategoryId is required")
                                       .Must(x => _context.Categories.Any(y => y.Id == x && y.IsActive)).WithMessage("Provided category id doesn't exist");

            RuleFor(x => x.Description).Cascade(CascadeMode.Stop)
                                       .NotEmpty().WithMessage("Description is required");

            RuleFor(x => x.ImagePath).Cascade(CascadeMode.Stop)
                                     .MinimumLength(5).WithMessage("Image must contain at least 5 charachetrs")
                                     .MaximumLength(150).WithMessage("Image can contain to 150 charachters");

            RuleFor(x => x.IngredientIds).Cascade(CascadeMode.Stop)
                                        .NotEmpty().WithMessage("IngredientId is required")
                                        .Must(x => x.Distinct().Count() == x.Count()).WithMessage("Duplicates are not allowed")
                                        .DependentRules(() =>
                                        {
                                            RuleForEach(x => x.IngredientIds).Must(x => _context.Ingredients.Any(y => y.Id == x && y.IsActive)).WithMessage("IngredientId doesn't exist");
                                        });
            RuleFor(x => x.SizeIds).Cascade(CascadeMode.Stop)
                                        .NotEmpty().WithMessage("SizeId is required")
                                        .Must(x => x.Distinct().Count() == x.Count()).WithMessage("Duplicates are not allowed")
                                        .DependentRules(() =>
                                        {
                                            RuleForEach(x => x.SizeIds).Must(x => _context.Sizes.Any(y => y.Id == x && y.IsActive)).WithMessage("SizeId doesn't exist");
                                        });
        }
    }
}

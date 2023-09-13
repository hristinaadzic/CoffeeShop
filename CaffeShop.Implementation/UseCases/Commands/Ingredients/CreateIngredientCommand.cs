using CoffeeShop.Application.UseCases.Commands.Ingredients;
using CoffeeShop.Application.UseCases.DTO;
using CoffeeShop.DataAccess;
using CoffeeShop.Domain;
using CoffeeShop.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Implementation.UseCases.Commands.Ingredients
{
    public class CreateIngredientCommand : EfUseCase, ICreateIngredientCommand
    {
        private CreateIngredientValidator _validator;
        public CreateIngredientCommand(Context context, CreateIngredientValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 7;

        public string Name => "Create ingredient";

        public string Description => "Create ingredient using EF";

        public void Execute(IngredientDto request)
        {
            _validator.ValidateAndThrow(request);

            var ingredient = new Ingredient
            {
                IngredientName = request.IngredientName,
                Quantity = request.Quantity
            };

            Context.Ingredients.Add(ingredient);
            Context.SaveChanges();
        }
    }
}

using CoffeeShop.Application.Exceptions;
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
    public class UpdateIngredientCommand : EfUseCase, IUpdateIngredientCommand
    {
        public UpdateIngredientCommand(Context context) : base(context)
        {
        }

        public int Id => 8;

        public string Name => "Update ingredient";

        public string Description => "Update ingredient using EF";

        public void Execute(IngredientDto request)
        {
            var id = request.id;
            var name = request.IngredientName;
            var quantity = request.Quantity;

            var ingredient = Context.Ingredients.FirstOrDefault(x => x.Id == id);

            if (ingredient == null)
            {
                throw new EntityNotFoundException(nameof(Ingredient), request);
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new Exception();
            }

            ingredient.IngredientName = name;
            ingredient.Quantity = quantity
                
                ;
            Context.SaveChanges();
        }
    }
}

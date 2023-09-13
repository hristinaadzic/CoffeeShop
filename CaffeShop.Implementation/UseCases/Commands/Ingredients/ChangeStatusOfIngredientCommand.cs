using CoffeeShop.Application.Exceptions;
using CoffeeShop.Application.UseCases.Commands.Ingredients;
using CoffeeShop.Application.UseCases.DTO;
using CoffeeShop.DataAccess;
using CoffeeShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Implementation.UseCases.Commands.Ingredients
{
    public class ChangeStatusOfIngredientCommand : EfUseCase, IChangeStatusOfIngredientCommand
    {
        public ChangeStatusOfIngredientCommand(Context context) : base(context)
        {
        }

        public int Id => 9;

        public string Name => "Change status of ingredient";

        public string Description => "Change status of ingredient (active/not active)";

        public void Execute(IngredientDto request)
        {
            var id = request.id;

            var ingredient = Context.Ingredients.FirstOrDefault(x => x.Id == id);

            if (ingredient == null)
            {
                throw new EntityNotFoundException(nameof(Ingredient), request);
            }

            if (ingredient.IsActive) ingredient.IsActive = false;
            else ingredient.IsActive = true;

            ingredient.UpdatedAt = DateTime.UtcNow;
            Context.SaveChanges();
        }
    }
}

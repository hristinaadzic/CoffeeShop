using CoffeeShop.Application.Exceptions;
using CoffeeShop.Application.UseCases.DTO;
using CoffeeShop.Application.UseCases.Queries.Ingredients;
using CoffeeShop.DataAccess;
using CoffeeShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Implementation.UseCases.Queries.Ingredients
{
    public class GetOneIngredientQuery : EfUseCase, IGetOneIngredientQuery
    {
        public GetOneIngredientQuery(Context context) : base(context)
        {
        }

        public int Id => 6;

        public string Name => "Get one ingredient";

        public string Description => "Get ingerdient by id using EF";

        public IngredientDto Execute(int request)
        {
            var ingredient = Context.Ingredients.Where(x => x.IsActive).AsQueryable().FirstOrDefault(x => x.Id == request);

            if (ingredient == null)
            {
                throw new EntityNotFoundException(nameof(Ingredient), request);
            }

            return new IngredientDto
            {
                id = ingredient.Id,
                IngredientName = ingredient.IngredientName,
                Quantity = ingredient.Quantity
            };
        }
    }
}

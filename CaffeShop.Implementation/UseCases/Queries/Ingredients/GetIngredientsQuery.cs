using CoffeeShop.Application.UseCases.DTO;
using CoffeeShop.Application.UseCases.DTO.Searches;
using CoffeeShop.Application.UseCases.Queries.Ingredients;
using CoffeeShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Implementation.UseCases.Queries.Ingredients
{
    public class GetIngredientsQuery : EfUseCase, IGetIngredientsQuery
    {
        public GetIngredientsQuery(Context context) : base(context)
        {
        }

        public int Id => 6;

        public string Name => "Create ingredient";

        public string Description => "Create ingredient using EF";

        public IEnumerable<IngredientDto> Execute(BaseSearch request)
        {
            var query = Context.Ingredients.Where(x => x.IsActive).AsQueryable();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.IngredientName.Contains(request.Keyword));
            }

            return query.Select(x => new IngredientDto
            {
                id = x.Id,
                IngredientName = x.IngredientName,
                Quantity = x.Quantity

            }).ToList();
        }
    }
}

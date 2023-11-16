using CoffeeShop.Application.Exceptions;
using CoffeeShop.Application.UseCases.DTO;
using CoffeeShop.Application.UseCases.Queries.Baverages;
using CoffeeShop.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Implementation.UseCases.Queries.Baverage
{
    public class GetOneBaverageQuery : EfUseCase, IGetOneBaverageQuery
    {
        public GetOneBaverageQuery(Context context) : base(context)
        {
        }

        public int Id => 16;

        public string Name => "Get one baverage";

        public string Description => "Get one baverage using EF";

        public BaverageDto Execute(int request)
        {
            var baverage = Context.Baverages.Where(x => x.IsActive)
                                            .Include(x => x.Category)
                                            .Include(x => x.BaverageIngredients)
                                            .ThenInclude(y => y.Ingredient)
                                            .Include(x => x.BaverageSizes)
                                            .ThenInclude(y => y.Size).AsQueryable().FirstOrDefault(x => x.Id == request);

            if (baverage == null)
            {
                throw new EntityNotFoundException(nameof(Baverage), request);
            }

            return new BaverageDto
            {
                id = baverage.Id,
                BaverageName = baverage.BaverageName,
                Category = baverage.Category.Name,
                ImagePath = baverage.ImagePath,
                Description = baverage.Description,
                Ingredients = baverage.BaverageIngredients.Select(x => new IngredientDto
                {
                    id = x.Ingredient.Id,
                    IngredientName = x.Ingredient.IngredientName
                }),
                Sizes = baverage.BaverageSizes.Select(x => new SizeDto
                {
                    id = x.Size.Id,
                    SizeValue = x.Size.SizeValue
                })
                
            };
        }
    }
}

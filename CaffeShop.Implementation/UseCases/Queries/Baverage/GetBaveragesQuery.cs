using CoffeeShop.Application.UseCases.DTO;
using CoffeeShop.Application.UseCases.DTO.Searches;
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
    public class GetBaveragesQuery : EfUseCase, IGetBaveragesQuery
    {
        public GetBaveragesQuery(Context context) : base(context)
        {
        }

        public int Id => 15;

        public string Name => "Search Baverages";

        public string Description => "Search baverage using EF";

        public IEnumerable<BaverageDto> Execute(BaseSearch request)
        {
            var query = Context.Baverages.Where(x => x.IsActive)
                                        .Include(x => x.Category)
                                        .Include(x => x.BaverageIngredients)
                                        .ThenInclude(y => y.Ingredient)
                                        .Include(x => x.BaverageSizes)
                                        .ThenInclude(z => z.Size).AsQueryable();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.BaverageName.Contains(request.Keyword) ||
                                         x.Description.Contains(request.Keyword) ||
                                         x.Category.Name.Contains(request.Keyword) ||
                                         x.BaverageIngredients.Any(x => x.Ingredient.IngredientName.Contains(request.Keyword)));
            }

            return query.Select(x => new BaverageDto
            {
                id = x.Id,
                BaverageName = x.BaverageName,
                Category = x.Category.Name,
                ImagePath = x.ImagePath,
                Description = x.Description,
                Ingredients = x.BaverageIngredients.Select(y => new IngredientDto
                {
                    id = y.Ingredient.Id,
                    IngredientName = y.Ingredient.IngredientName
                }),
                Sizes = x.BaverageSizes.Select(y => new SizeDto
                {
                    id = y.Size.Id,
                    SizeValue = y.Size.SizeValue
                })
                

            }).ToList();
        }
    }
}

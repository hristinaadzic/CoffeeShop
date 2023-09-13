using CoffeeShop.Application.UseCases.DTO;
using CoffeeShop.Application.UseCases.DTO.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Application.UseCases.Queries.Ingredients
{
    public interface IGetIngredientsQuery : IQuery<BaseSearch, IEnumerable<IngredientDto>>
    {
    }
}

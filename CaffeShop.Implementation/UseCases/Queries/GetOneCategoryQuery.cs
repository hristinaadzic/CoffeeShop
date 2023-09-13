using CoffeeShop.Application.Exceptions;
using CoffeeShop.Application.UseCases.DTO;
using CoffeeShop.Application.UseCases.Queries.Categories;
using CoffeeShop.DataAccess;
using CoffeeShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Implementation.UseCases.Queries
{
    public class GetOneCategoryQuery : EfUseCase, IGetOneCategoryQuery
    {
        public GetOneCategoryQuery(Context context) : base(context)
        {
        }

        public int Id => 3;

        public string Name => "Get one category";

        public string Description => "Get category by id";

        public CategoryDto Execute(int request)
        {
            var category = Context.Categories.Where(x => x.IsActive).AsQueryable().FirstOrDefault(x => x.Id == request);

            if (category == null)
            {
                throw new EntityNotFoundException(nameof(Category), request);
            }

            return new CategoryDto
            {
                id = category.Id,
                Name = category.Name
            };
        }
    }
}

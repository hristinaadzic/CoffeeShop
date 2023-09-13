using CoffeeShop.Application.Exceptions;
using CoffeeShop.Application.UseCases.Commands.Categories;
using CoffeeShop.Application.UseCases.DTO;
using CoffeeShop.DataAccess;
using CoffeeShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Implementation.UseCases.Commands.Categories
{
    public class ChangeStatusOfCategoryCommand : EfUseCase, IChangeStatusOfCategoryCommand
    {
        public ChangeStatusOfCategoryCommand(Context context) : base(context)
        {
        }

        public int Id => 5;

        public string Name => "Change satus of category";

        public string Description => "Change status of category (active/not active)";

        public void Execute(CategoryDto request)
        {
            var id = request.id;

            var category = Context.Categories.FirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                throw new EntityNotFoundException(nameof(Category), request);
            }

            if (category.IsActive) category.IsActive = false;
            else category.IsActive = true;

            category.UpdatedAt = DateTime.UtcNow;
            Context.SaveChanges();
        }
    }
}

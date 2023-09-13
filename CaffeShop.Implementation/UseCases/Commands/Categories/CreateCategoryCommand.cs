using CoffeeShop.Application.UseCases.Commands.Categories;
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

namespace CoffeeShop.Implementation.UseCases.Commands.Categories
{
    public class CreateCategoryCommand : EfUseCase, ICreateCategoryCommand
    {
        private CreateCategoryValidator _validator;
        public CreateCategoryCommand(Context context, CreateCategoryValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 2;

        public string Name => "Create new category";

        public string Description => "Creating new category using EF";

        public void Execute(CategoryDto request)
        {
            _validator.ValidateAndThrow(request);

            var category = new Category
            {
                Name = request.Name
            };

            Context.Categories.Add(category);
            Context.SaveChanges();
        }
    }
}

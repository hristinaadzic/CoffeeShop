using CoffeeShop.Application.UseCases.Commands.Baverages;
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

namespace CoffeeShop.Implementation.UseCases.Commands.Baverage
{
    public class CreateBaverageCommand : EfUseCase, ICreateBaverageCommand
    {
        CreateBaverageValidator _validator;
        public CreateBaverageCommand(Context context, CreateBaverageValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 18;

        public string Name => "Create baverage";

        public string Description => "Create baverage using EF";

        public void Execute(CreateBaverageDto request)
        {
            _validator.ValidateAndThrow(request);

            var baverage = new Domain.Baverage
            {
                BaverageName = request.BaverageName,
                CategoryId = request.CategoryId,
                ImagePath = request.ImagePath,
                Description = request.Description,
                BaverageIngredients = request.IngredientIds.Select(x => new BaverageIngredient
                {
                    IngredientId = x
                }).ToList(),
                BaverageSizes = request.SizeIds.Select(x => new BaverageSize
                {
                    SizeId = x
                }).ToList()
            };
               
            Context.Add(baverage);
            Context.SaveChanges();
        }
    }
}

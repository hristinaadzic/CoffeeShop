using CoffeeShop.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Application.UseCases.Commands.Categories
{
    public interface IChangeStatusOfCategoryCommand : ICommand<CategoryDto>
    {
    }
}

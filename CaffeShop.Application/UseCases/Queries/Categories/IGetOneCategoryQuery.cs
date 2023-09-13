﻿using CoffeeShop.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Application.UseCases.Queries.Categories
{
    public interface IGetOneCategoryQuery : IQuery<int, CategoryDto>
    {
    }
}

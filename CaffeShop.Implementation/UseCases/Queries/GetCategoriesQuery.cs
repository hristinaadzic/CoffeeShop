﻿using CoffeeShop.Application.UseCases.DTO;
using CoffeeShop.Application.UseCases.DTO.Searches;
using CoffeeShop.Application.UseCases.Queries.Categories;
using CoffeeShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Implementation.UseCases.Queries
{
    public class GetCategoriesQuery : EfUseCase, IGetCategoriesQuery
    {
        public GetCategoriesQuery(Context context) : base(context)
        {
        }

        public int Id => 1;

        public string Name => "Search Categories";

        public string Description => "Searching categories using EF";

        public IEnumerable<CategoryDto> Execute(BaseSearch request)
        {
            var query = Context.Categories.Where(x => x.IsActive).AsQueryable();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.Name.Contains(request.Keyword));
            }

            return query.Select(x => new CategoryDto
            {
                id = x.Id,
                Name = x.Name

            }).ToList();
        }

    }
}

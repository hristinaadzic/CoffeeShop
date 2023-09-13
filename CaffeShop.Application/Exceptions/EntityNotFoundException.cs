using CoffeeShop.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        private CategoryDto request;

        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string v, Dto request)
        {
        }

        public EntityNotFoundException(string entityType, int id)
            : base($"Entity of type {entityType} with an id of {id} was not found.")
        {

        }

        public EntityNotFoundException(string message, CategoryDto request) : base(message)
        {
            this.request = request;
        }
    }
}

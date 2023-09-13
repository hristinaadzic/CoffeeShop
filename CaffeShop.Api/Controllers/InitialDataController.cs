using CoffeeShop.DataAccess;
using CoffeeShop.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitialDataController : ControllerBase
    {
        private Context _context;
        public InitialDataController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post()
        {
            if (_context.Categories.Any())
            {
                return Conflict();
            }

            var categories = new List<Category>
            {
                new Category { Name = "Espresso"},
                new Category { Name = "Nescafe"},
                new Category { Name = "Tea"},
                new Category { Name = "Coffee alternatives"}
            };

            var ingredients = new List<Ingredient>
            {
                new Ingredient{ IngredientName = "Espresso", Quantity = 1000},
                new Ingredient{ IngredientName = "Milk", Quantity = 1000},
                new Ingredient{ IngredientName = "Sugar", Quantity = 1000},
                new Ingredient{ IngredientName = "Chocolate", Quantity = 1000},
            };

            var sizes = new List<Size>
            {
                new Size { SizeValue = "S"},
                new Size { SizeValue = "M"},
                new Size { SizeValue = "L"}
            };

            var roles = new List<Role>
            {
                new Role {Name="Admin"},
                new Role {Name="User"}
            };

            _context.AddRange(categories);
            _context.AddRange(ingredients);
            _context.AddRange(sizes);
            _context.AddRange(roles);

            _context.SaveChanges();

            return StatusCode(201);

            
        }
    }
}

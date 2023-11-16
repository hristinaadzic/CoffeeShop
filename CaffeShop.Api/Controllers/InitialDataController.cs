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
                new Size { SizeValue = "Small"},
                new Size { SizeValue = "Medium"},
                new Size { SizeValue = "Large"}
            };

            var roles = new List<Role>
            {
                new Role {Name="Admin"},
                new Role {Name="User"}
            };

            var payments = new List<Payment>
            {
                new Payment{PaymentMethod = "Cash"},
                new Payment{PaymentMethod = "Card"}
            };

            var baverages = new List<Baverage>
            {
                new Baverage
                {
                    BaverageName = "Latte",
                    ImagePath = "latte.jpg",
                    Description = "A latte or caffè latte is a milk coffee that is a made up of one or two shots of espresso, steamed milk and a final, thin layer of frothed milk on top.",
                    Category = categories.ElementAt(0),
                    BaverageSizes = new List<BaverageSize>
                    {
                        new BaverageSize{Size = sizes.ElementAt(0), Price = 5 },
                        new BaverageSize{Size = sizes.ElementAt(1), Price = 7 },
                        new BaverageSize{Size = sizes.ElementAt(2), Price = 10}
                    },
                    BaverageIngredients = new List<BaverageIngredient>
                    {
                        new BaverageIngredient{Ingredient = ingredients.ElementAt(0)},
                        new BaverageIngredient{Ingredient = ingredients.ElementAt(1)}
                    }
                },
                new Baverage
                {
                    BaverageName = "Mocha",
                    ImagePath = "mocha.jpg",
                    Description = "Although a mocha is often interpreted differently across the world, the basis is that a shot of espresso is combined with chocolate powder or syrup, followed by milk or cream. It is a variant of a latte, in the sense that it is often 1/3 espresso and 2/3 steamed milk.",
                    Category = categories.ElementAt(0),
                    BaverageSizes = new List<BaverageSize>
                    {
                        new BaverageSize{Size = sizes.ElementAt(0), Price = 5 },
                        new BaverageSize{Size = sizes.ElementAt(1), Price = 7 },
                        new BaverageSize{Size = sizes.ElementAt(2), Price = 10}
                    },
                    BaverageIngredients = new List<BaverageIngredient>
                    {
                        new BaverageIngredient{Ingredient = ingredients.ElementAt(0)},
                        new BaverageIngredient{Ingredient = ingredients.ElementAt(1)},
                        new BaverageIngredient{Ingredient = ingredients.ElementAt(3)}
                    }
                }
            };

            var users = new List<User>
            {
                new User {FirstName = "Pera", LastName = "Peric", Email = "peraperic@gmail.com", Password = "5f92753be4de30d54a72d424de1179d54d8a56754a2deed9a63ea83eef0cfc34", Role = roles.ElementAt(0)},
                new User {FirstName = "Mika", LastName = "Mikic", Email = "mikamikic@gmail.com", Password = "c73f1b3779957b0a4c6dc449cedc71d3e2f79108f124f366b32f4db2e51baaef", Role = roles.ElementAt(1)},
            };

            _context.AddRange(categories);
            _context.AddRange(ingredients);
            _context.AddRange(sizes);
            _context.AddRange(roles);
            _context.AddRange(payments);
            _context.AddRange(users);
            _context.AddRange(baverages);

            _context.SaveChanges();

            return StatusCode(201);

            
        }
    }
}

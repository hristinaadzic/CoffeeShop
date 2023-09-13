using CoffeeShop.Application.UseCases.Commands.User;
using CoffeeShop.Application.UseCases.DTO;
using CoffeeShop.DataAccess;
using CoffeeShop.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Implementation.UseCases.Commands.User
{
    public class RegisterUserCommand : EfUseCase, IRegisterUserCommand
    {
        private RegisterUserValidator _validator;
        public RegisterUserCommand(Context context, RegisterUserValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 10;

        public string Name => "Register user";

        public string Description => "register user using EF";

        public void Execute(RegisterDto request)
        {
            _validator.ValidateAndThrow(request);

            var user = new CoffeeShop.Domain.User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = sha256_hash(request.Password),
                RoleId = request.RoleId
            };

            Context.Users.Add(user);
            Context.SaveChanges();
        }

        private String sha256_hash(String value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}

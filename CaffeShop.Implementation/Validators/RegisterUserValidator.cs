using CoffeeShop.Application.UseCases.DTO;
using CoffeeShop.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Implementation.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterDto>
    {
        private Context _context;

        public RegisterUserValidator(Context context)
        {
            _context = context;

            var nameRegex = @"^[A-Z][a-z]{2,}(\s[A-Z][a-z]{2,})?$";

            RuleFor(x => x.FirstName).Cascade(CascadeMode.Stop)
                                     .NotEmpty().WithMessage("First name is required")
                                     .Matches(nameRegex).WithMessage("First name is not in the right format");

            RuleFor(x => x.LastName).Cascade(CascadeMode.Stop)
                                     .NotEmpty().WithMessage("Last name is required")
                                     .Matches(nameRegex).WithMessage("Last name is not in the right format");

            RuleFor(x => x.Email).Cascade(CascadeMode.Stop)
                                 .NotEmpty().WithMessage("Email is required")
                                 .EmailAddress().WithMessage("Email is not in the right format")
                                 .Must(x => !context.Users.Any(u => u.Email == x)).WithMessage("Email {PropertyValue} is already in use");

            RuleFor(x => x.Password).Cascade(CascadeMode.Stop)
                                    .NotEmpty().WithMessage("Password is required")
                                   .Matches(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$").WithMessage("Password must contain minimum 8 characters, at least one letter and one number");

        }
    }
}

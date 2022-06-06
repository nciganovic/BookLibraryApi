using Application.Dto.Account;
using Application.Hash;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validator
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        private readonly BookLibraryContext _context;

        public LoginValidator(BookLibraryContext context)
        {
            _context = context;

            RuleFor(x => x.Email)
                .NotEmpty()
                .Must(x => UserExist(x))
                .EmailAddress()
                .WithMessage("User with email = {PropertyValue} doesn't exist.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Password)
                        .NotEmpty()
                        .Must((dto, x) => CheckPassword(dto))
                        .WithMessage("Password is invalid.");
                });
        }

        public bool UserExist(string email)
        {
            return _context.Users.Where(x => x.Email == email).FirstOrDefault() is not null;
        }

        private bool CheckPassword(LoginDto dto)
        {
            var user = _context.Users.Where(x => x.Email == dto.Email).FirstOrDefault();
            if (user is not null)
               return Password.VerifyPassword(dto.Password, user.Password, user.Salt);
            return false;
        }
    }
}

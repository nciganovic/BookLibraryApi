using Application.Dto.User;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validator
{
    public class ChangeUserValidator : UserValidator<ChangeUserDto>
    {
        public ChangeUserValidator(BookLibraryContext context) : base(context)
        {
            RuleFor(x => x.Email)
             .NotEmpty()
             .Must((dto, x) => EmailUnique(dto))
             .WithMessage("Email {PropertyValue} is already taken.");
        }

        public bool EmailUnique(ChangeUserDto dto)
        {
            return _context.Users.Where(x => x.Id != dto.Id && x.Email == dto.Email).FirstOrDefault() == null;
        }
    }
}

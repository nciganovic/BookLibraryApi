using Application.Dto.User;
using DataAccess;
using FluentValidation;
using System.Linq;

namespace Implementation.Validator
{
    public class AddUserValidator : UserValidator<AddUserDto>
    { 
        public AddUserValidator(BookLibraryContext context) : base(context)
        {
            RuleFor(x => x.Email)
             .NotEmpty()
             .EmailAddress()
             .Must(x => EmailUnique(x))
             .WithMessage("Email {PropertyValue} is already taken.");
        }

        public bool EmailUnique(string value)
        {
            return _context.Users.Where(x => x.Email == value).FirstOrDefault() == null;
        }
    }
}

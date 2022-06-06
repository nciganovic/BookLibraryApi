using Application.Dto.Account;
using DataAccess;
using FluentValidation;
using System.Linq;

namespace Implementation.Validator
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        private BookLibraryContext _context;

        public RegisterValidator(BookLibraryContext context)
        {
            _context = context;

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .Must(x => !IsEmailAlreadyTaken(x))
                .WithMessage("Email {PropertyValue} is already taken");

            RuleFor(x => x.MembershipId)
                 .Must(x => MembershipExists(x))
                 .WithMessage("Membership with id = {PropertyValue} does not exist.");
        }

        private bool IsEmailAlreadyTaken(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email) is not null;
        }

        public bool MembershipExists(int value)
        {
            return _context.Memberships.Where(x => x.Id == value).FirstOrDefault() != null;
        }
    }
}

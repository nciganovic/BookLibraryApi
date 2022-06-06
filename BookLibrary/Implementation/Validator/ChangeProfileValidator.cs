using Application.Dto.Account;
using DataAccess;
using FluentValidation;
using System.Linq;

namespace Implementation.Validator
{
    public class ChangeProfileValidator : AbstractValidator<ChangeProfileDto>
    {
        private BookLibraryContext _context;

        public ChangeProfileValidator(BookLibraryContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .Must(x => UserExist(x))
                .WithMessage("User with id = {PropertyValue} does not exist.");

            RuleFor(x => x.FirstName)
                .MaximumLength(30);

            RuleFor(x => x.LastName)
                .MaximumLength(30);

            RuleFor(x => x.Password)
                .MinimumLength(8);

            RuleFor(x => x.Email)
                .EmailAddress()
                .Must((dto, x) => !IsEmailAlreadyTaken(dto))
                .WithMessage("Email {PropertyValue} is already taken");

            RuleFor(x => x.MembershipId)
                 .Must(x => ValidMembership(x))
                 .WithMessage("Membership with id = {PropertyValue} does not exist.");
        }

        private bool UserExist(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id) is not null;
        }

        private bool IsEmailAlreadyTaken(ChangeProfileDto dto)
        {
            return _context.Users.FirstOrDefault(x => x.Email == dto.Email && x.Id != dto.Id) is not null;
        }

        public bool ValidMembership(int? value)
        {
            if(value is not null)
                return _context.Memberships.Where(x => x.Id == value).FirstOrDefault() != null;
            return true;
        }
    }
}

using Application.Dto.Author;
using Application.Dto.User;
using DataAccess;
using FluentValidation;
using System.Linq;

namespace Implementation.Validator
{
    public class UserValidator<T> : AbstractValidator<T> where T : IUserCommandDto
    {
        protected BookLibraryContext _context;

        public UserValidator(BookLibraryContext context)
        {
            _context = context;

            RuleFor(x => x.FirstName)
                .MaximumLength(30)
                .NotEmpty();

            RuleFor(x => x.LastName)
                .MaximumLength(30)
                .NotEmpty();

            RuleFor(x => x.Password)
                .MinimumLength(8)
                .NotEmpty();

            RuleFor(x => x.RoleId)
                .Must(x => RoleExists(x))
                .WithMessage("Role with id = {PropertyValue} does not exist.");

            RuleFor(x => x.MembershipId)
                .Must(x => MembershipUnique(x))
                .WithMessage("Membership with id = {PropertyValue} does not exist.");
        }

        public bool RoleExists(int value)
        {
            return _context.Roles.Where(x => x.Id == value).FirstOrDefault() != null;
        }

        public bool MembershipUnique(int value)
        {
            return _context.Memberships.Where(x => x.Id == value).FirstOrDefault() != null;
        }
    }
}

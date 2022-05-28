using Application.Dto.Membership;
using DataAccess;
using FluentValidation;
using System.Linq;

namespace Implementation.Validator
{
    public class AddMembershipValidator : AbstractValidator<AddMembershipDto>
    {
        private BookLibraryContext _context;

        public AddMembershipValidator(BookLibraryContext context)
        {
            _context = context;

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.Name)
                .Must(x => IsNameUnique(x))
                .WithMessage("'{PropertyValue}' already exists.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(30);
            
            RuleFor(x => x.MonthlyFee)
                .GreaterThan(0);
        }

        public bool IsNameUnique(string value)
        {
            return _context.Memberships.Where(x => x.Name == value).FirstOrDefault() == null;
        }
    }
}

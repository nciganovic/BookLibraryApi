using Application.Dto;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validator
{
    public class ChangeMembershipValidator : AbstractValidator<ChangeMembershipDto>
    {
        private BookLibraryContext _context;

        public ChangeMembershipValidator(BookLibraryContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .Must(x => MembershipExists(x))
                .WithMessage("Membership with {PropertyValue} does not exist.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.Name)
                .Must((dto, m) => IsNameUnique(dto))
                .WithMessage("Membership name {PropertyValue} is already taken.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.MonthlyFee)
                .GreaterThan(0);
        }

        public bool MembershipExists(int id)
        {
            return _context.Memberships
                .Where(x => x.Id == id)
                .FirstOrDefault() != null;
        }

        public bool IsNameUnique(ChangeMembershipDto dto)
        {
            return _context.Memberships
                .Where(x => x.Name == dto.Name && x.Id != dto.Id)
                .FirstOrDefault() == null;
        }

    }
}

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
    public class AddMembershipValidator : AbstractValidator<AddMembershipDto>
    {
        private BookLibraryContext _context;

        public AddMembershipValidator(BookLibraryContext context)
        {
            _context = context;

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(30);
            
            RuleFor(x => x.MonthlyFee)
                .GreaterThan(0);
        }
    }
}

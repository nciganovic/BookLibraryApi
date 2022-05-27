using Application.Dto.Author;
using DataAccess;
using FluentValidation;
using System.Linq;

namespace Implementation.Validator
{
    public class AddAuthorValidator : AbstractValidator<AddAuthorDto>
    {
        private BookLibraryContext _context;

        public AddAuthorValidator(BookLibraryContext context)
        {
            _context = context;

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(30);
        }
    }
}

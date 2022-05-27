using Application.Dto.Author;
using DataAccess;
using FluentValidation;
using System.Linq;

namespace Implementation.Validator
{
    public class ChangeAuthorValidator : AbstractValidator<ChangeAuthorDto>
    {
        private BookLibraryContext _context;

        public ChangeAuthorValidator(BookLibraryContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .Must(x => ItemExists(x))
                .WithMessage("Author with id = {PropertyValue} does not exist.");

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(30);
        }

        public bool ItemExists(int id)
        {
            return _context.Authors
                .Where(x => x.Id == id)
                .FirstOrDefault() != null;
        }
    }
}

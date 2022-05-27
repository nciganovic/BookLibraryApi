using Application.Dto.Format;
using DataAccess;
using FluentValidation;
using System.Linq;

namespace Implementation.Validator
{
    public class AddFormatValidator : AbstractValidator<AddFormatDto>
    {
        private BookLibraryContext _context;

        public AddFormatValidator(BookLibraryContext context)
        {
            _context = context;

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.Name)
                .Must(x => IsNameUnique(x))
                .WithMessage("Name must have unique value");
        }

        public bool IsNameUnique(string value)
        {
            return _context.Formats.Where(x => x.Name == value).FirstOrDefault() == null;
        }
    }
}

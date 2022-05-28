using Application.Dto.Format;
using DataAccess;
using FluentValidation;
using System.Linq;

namespace Implementation.Validator
{
    public class ChangeFormatValidator : AbstractValidator<ChangeFormatDto>
    {
        private BookLibraryContext _context;

        public ChangeFormatValidator(BookLibraryContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .Must(x => ItemExists(x))
                .WithMessage("Format with id = {PropertyValue} does not exist.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.Name)
                .Must((dto, m) => IsNameUnique(dto))
                .WithMessage("Format name = '{PropertyValue}' already exists.");
        }

        public bool ItemExists(int id)
        {
            return _context.Formats
                .Where(x => x.Id == id)
                .FirstOrDefault() != null;
        }

        public bool IsNameUnique(ChangeFormatDto dto)
        {
            return _context.Formats
                .Where(x => x.Name == dto.Name && x.Id != dto.Id)
                .FirstOrDefault() == null;
        }
    }
}

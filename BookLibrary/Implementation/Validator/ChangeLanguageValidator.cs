using Application.Dto.Language;
using DataAccess;
using FluentValidation;
using System.Linq;

namespace Implementation.Validator
{
    public class ChangeLanguageValidator : AbstractValidator<ChangeLanguageDto>
    {
        private BookLibraryContext _context;

        public ChangeLanguageValidator(BookLibraryContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .Must(x => ItemExists(x))
                .WithMessage("Language with id = {PropertyValue} does not exist.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.Name)
                .Must((dto, m) => IsNameUnique(dto))
                .WithMessage("Language name = '{PropertyValue}' is already taken.");
        }

        public bool ItemExists(int id)
        {
            return _context.Languages
                .Where(x => x.Id == id)
                .FirstOrDefault() != null;
        }

        public bool IsNameUnique(ChangeLanguageDto dto)
        {
            return _context.Languages
                .Where(x => x.Name == dto.Name && x.Id != dto.Id)
                .FirstOrDefault() == null;
        }
    }
}

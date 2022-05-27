using Application.Dto.Language;
using DataAccess;
using FluentValidation;
using System.Linq;

namespace Implementation.Validator
{
    public class AddLanguageValidator : AbstractValidator<AddLanguageDto>
    {
        private BookLibraryContext _context;

        public AddLanguageValidator(BookLibraryContext context)
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
            return _context.Languages.Where(x => x.Name == value).FirstOrDefault() == null;
        }
    }
}

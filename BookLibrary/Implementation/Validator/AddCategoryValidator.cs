using Application.Dto.Category;
using DataAccess;
using FluentValidation;
using System.Linq;

namespace Implementation.Validator
{
    public class AddCategoryValidator : AbstractValidator<AddCategoryDto>
    {
        private BookLibraryContext _context;

        public AddCategoryValidator(BookLibraryContext context)
        {
            _context = context;

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.Name)
                .Must(x => IsNameUnique(x))
                .WithMessage("'{PropertyValue}' already exists.");
        }

        public bool IsNameUnique(string value)
        {
            return _context.Categories.Where(x => x.Name == value).FirstOrDefault() == null;
        }
    }
}

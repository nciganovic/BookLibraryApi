using Application.Dto.Category;
using DataAccess;
using FluentValidation;
using System.Linq;

namespace Implementation.Validator
{
    public class ChangeCategoryValidator : AbstractValidator<ChangeCategoryDto>
    {
        private BookLibraryContext _context;

        public ChangeCategoryValidator(BookLibraryContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .Must(x => ItemExists(x))
                .WithMessage("Category with id = {PropertyValue} does not exist.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.Name)
                .Must((dto, m) => IsNameUnique(dto))
                .WithMessage("Category name = '{PropertyValue}' already exists.");
        }

        public bool ItemExists(int id)
        {
            return _context.Categories
                .Where(x => x.Id == id)
                .FirstOrDefault() != null;
        }

        public bool IsNameUnique(ChangeCategoryDto dto)
        {
            return _context.Categories
                .Where(x => x.Name == dto.Name && x.Id != dto.Id)
                .FirstOrDefault() == null;
        }
    }
}

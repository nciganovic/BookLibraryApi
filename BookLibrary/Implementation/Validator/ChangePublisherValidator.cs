using Application.Dto.Publisher;
using DataAccess;
using FluentValidation;
using System.Linq;

namespace Implementation.Validator
{
    public class ChangePublisherValidator : AbstractValidator<ChangePublisherDto>
    {
        private BookLibraryContext _context;

        public ChangePublisherValidator(BookLibraryContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .Must(x => ItemExists(x))
                .WithMessage("Publisher with id = {PropertyValue} does not exist.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.Name)
                .Must((dto, m) => IsNameUnique(dto))
                .WithMessage("Publisher name = '{PropertyValue}' already exists.");
        }

        public bool ItemExists(int id)
        {
            return _context.Publishers
                .Where(x => x.Id == id)
                .FirstOrDefault() != null;
        }

        public bool IsNameUnique(ChangePublisherDto dto)
        {
            return _context.Publishers
                .Where(x => x.Name == dto.Name && x.Id != dto.Id)
                .FirstOrDefault() == null;
        }
    }
}

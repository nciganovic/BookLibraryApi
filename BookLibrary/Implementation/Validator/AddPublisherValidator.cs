using Application.Dto.Publisher;
using DataAccess;
using FluentValidation;
using System.Linq;


namespace Implementation.Validator
{
    public class AddPublisherValidator : AbstractValidator<AddPublisherDto>
    {
        private BookLibraryContext _context;

        public AddPublisherValidator(BookLibraryContext context)
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
            return _context.Publishers.Where(x => x.Name == value).FirstOrDefault() == null;
        }
    }
}

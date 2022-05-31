using Application.Dto.Book;
using DataAccess;
using FluentValidation;

namespace Implementation.Validator
{
    public class ChangeBookValidator : BookValidator<ChangeBookDto>
    {
        public ChangeBookValidator(BookLibraryContext context) : base(context)
        {
            RuleFor(x => x.Id)
                .Must(x => BookExists(x))
                .WithMessage("Book with id = '{PropertyValue}' does not exist.");
        }

        private bool BookExists(int id)
        {
            return _context.Books.Find(id) != null;
        }
    }
}

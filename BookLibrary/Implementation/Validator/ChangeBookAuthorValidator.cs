using Application.Dto.Book;
using DataAccess;
using FluentValidation;

namespace Implementation.Validator
{
    public class ChangeBookAuthorValidator : AbstractValidator<ChangeBookAuthorsDto>
    {
        private BookLibraryContext _context;

        public ChangeBookAuthorValidator(BookLibraryContext context)
        {
            _context = context;

            RuleFor(x => x.BookId)
               .Must(x => BookExists(x))
               .WithMessage("Book with id = '{PropertyValue}' does not exist.");

            RuleFor(x => x.AuthorIds)
                .NotNull();

            RuleForEach(x => x.AuthorIds)
               .NotEmpty()
               .NotNull()
               .Must(x => AuthorExists(x))
               .WithMessage("Author with id = '{PropertyValue}' does not exist.");
        }

        private bool BookExists(int id)
        {
            return _context.Books.Find(id) != null;
        }

        private bool AuthorExists(int id)
        { 
            return _context.Authors.Find(id) != null;
        }
    }
}

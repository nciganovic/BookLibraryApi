using Application.Dto.Book;
using DataAccess;
using FluentValidation;

namespace Implementation.Validator
{
    public class AddBookValidator : BookValidator<AddBookDto>
    {
        public AddBookValidator(BookLibraryContext context) : base(context)
        {
            RuleFor(x => x.AuthorIds)
               .NotNull();

            RuleForEach(x => x.AuthorIds).ChildRules(id =>
            {
                id.RuleFor(x => x).Must(x => AuthorExists(x)).WithMessage($"Author with id = '{id}' does not exist.'");
            });
        }

        private bool AuthorExists(int id)
        {
            return _context.Authors.Find(id) != null;
        }
    }
}
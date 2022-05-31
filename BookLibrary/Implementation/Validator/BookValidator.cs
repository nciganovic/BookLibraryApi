using Application.Dto.Book;
using DataAccess;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Implementation.Validator
{
    public class BookValidator<T> : AbstractValidator<T> where T : IBookCommandDto
    {
        protected BookLibraryContext _context;

        public BookValidator(BookLibraryContext context)
        {
            _context = context;

            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(80);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(x => x.Pages)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.AvailableUnits)
                .NotEmpty()
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.Year)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.ContentFile)
                .Must(x => LessThenMb(x, 2))
                .WithMessage("File must be less then 2mb'");

            RuleFor(x => x.CoverImage)
                .Must(x => LessThenMb(x, 2))
                .WithMessage("Image must be less then 2mb'");

            RuleFor(x => x.PublisherId)
                .Must(x => PublisherExists(x))
                .WithMessage("Publisher with id = '{PropertyValue}' does not exist.'");

            RuleFor(x => x.LanguageId)
                .Must(x => LangageExists(x))
                .WithMessage("Langage with id = '{PropertyValue}' does not exist.'");

            RuleFor(x => x.FormatId)
                .Must(x => FormatExists(x))
                .WithMessage("Format with id = '{PropertyValue}' does not exist.'");

            RuleFor(x => x.CategoryId)
               .Must(x => CategoryExists(x))
               .WithMessage("Category with id = '{PropertyValue}' does not exist.'");

            RuleForEach(x => x.AuthorIds).ChildRules(id =>
            {
                id.RuleFor(x => x).Must(x => AuthorExists(x)).WithMessage($"Author with id = '{id}' does not exist.'");
            });
        }

        private bool PublisherExists(int id)
        {
            return _context.Publishers.Find(id) != null;
        }

        private bool LangageExists(int id)
        {
            return _context.Languages.Find(id) != null;
        }

        private bool FormatExists(int id)
        {
            return _context.Formats.Find(id) != null;
        }

        private bool AuthorExists(int id)
        {
            return _context.Authors.Find(id) != null;
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Find(id) != null;
        }

        private bool LessThenMb(IFormFile file, int megabyte)
        {
            if(file != null)
                return ConvertKbToMb(file.Length) < megabyte;
            return true; //Skip validation if file does not exist
        }

        private decimal ConvertKbToMb(long value)
        {
            return value / 1000000;
        }
    }
}

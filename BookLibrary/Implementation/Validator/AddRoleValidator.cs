using Application.Dto.Role;
using DataAccess;
using FluentValidation;
using System.Linq;

namespace Implementation.Validator
{
    public class AddRoleValidator : AbstractValidator<AddRoleDto>
    {
        private BookLibraryContext _context;

        public AddRoleValidator(BookLibraryContext context)
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
            return _context.Roles.Where(x => x.Name == value).FirstOrDefault() == null;
        }
    }
}

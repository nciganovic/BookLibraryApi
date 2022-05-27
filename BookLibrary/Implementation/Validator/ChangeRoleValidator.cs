using Application.Dto.Role;
using DataAccess;
using FluentValidation;
using System.Linq;

namespace Implementation.Validator
{
    public class ChangeRoleValidator : AbstractValidator<ChangeRoleDto>
    {
        private BookLibraryContext _context;

        public ChangeRoleValidator(BookLibraryContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .Must(x => ItemExists(x))
                .WithMessage("Role with id = {PropertyValue} does not exist.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.Name)
                .Must((dto, m) => IsNameUnique(dto))
                .WithMessage("Role name = '{PropertyValue}' is already taken.");
        }

        public bool ItemExists(int id)
        {
            return _context.Roles
                .Where(x => x.Id == id)
                .FirstOrDefault() != null;
        }

        public bool IsNameUnique(ChangeRoleDto dto)
        {
            return _context.Roles
                .Where(x => x.Name == dto.Name && x.Id != dto.Id)
                .FirstOrDefault() == null;
        }
    }
}

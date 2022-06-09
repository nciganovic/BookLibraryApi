using Application.Dto.RoleCase;
using DataAccess;
using FluentValidation;
using System.Linq;

namespace Implementation.Validator
{
    public class AddRoleCaseValidator : AbstractValidator<RoleCaseDto>
    {
        private readonly BookLibraryContext _context;

        public AddRoleCaseValidator(BookLibraryContext context)
        {
            _context = context;

            RuleFor(x => x.RoleId)
                .NotEmpty()
                .DependentRules(() =>
                {
                    RuleFor(x => x.RoleId)
                        .Must(x => RoleExists((int)x))
                        .WithMessage("ApplicationUser with id = '{PropertyValue}' doesn't exist.")
                        .DependentRules(() =>
                        {
                            RuleFor(x => x.UseCaseId)
                                .NotEmpty()
                                .DependentRules(() =>
                                {
                                    RuleFor(x => x.UseCaseId)
                                        .Must((dto, caseId) => !RoleCaseExists(dto))
                                        .WithMessage("Entity already exists.");
                                });
                        });

                });

        }

        private bool RoleExists(int id)
        {
            return _context.Roles.Find(id) != null;
        }

        private bool RoleCaseExists(RoleCaseDto dto)
        {
            return _context.RoleUserCases.FirstOrDefault(x => x.RoleId == dto.RoleId && x.UseCaseId == dto.UseCaseId) != null;
        }
    }
}

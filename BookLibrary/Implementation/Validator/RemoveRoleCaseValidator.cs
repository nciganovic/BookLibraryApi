using Application;
using Application.Dto.RoleCase;
using DataAccess;
using FluentValidation;
using System.Linq;

namespace Implementation.Validator
{
    public class RemoveRoleCaseValidator : AbstractValidator<RoleCaseDto>
    {
        private readonly BookLibraryContext _context;

        public RemoveRoleCaseValidator(BookLibraryContext context)
        {
            _context = context;

            RuleFor(x => x.RoleId)
                .Must((dto, userId) => RoleUseCaseExists(dto))
                .WithMessage("Entity with given RoleId and CaseId doesn't exist");

        }

        private bool RoleUseCaseExists(RoleCaseDto dto)
        {
            return _context.RoleUserCases.FirstOrDefault(x => x.RoleId == dto.RoleId && x.UseCaseId == dto.UseCaseId) != null;
        }
    }
}

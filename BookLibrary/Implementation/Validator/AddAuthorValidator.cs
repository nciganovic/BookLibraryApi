using Application.Dto.Author;
using DataAccess;
using FluentValidation;
using System.Linq;

namespace Implementation.Validator
{
    public class AddAuthorValidator : AbstractValidator<AddAuthorDto>
    {
        public AddAuthorValidator()
        { 
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.Bio)
                .NotEmpty()
                .MaximumLength(300);
        }
    }
}

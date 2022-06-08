using Application.Dto.Reservation;
using Application.Extensions;
using Application.Helper;
using DataAccess;
using FluentValidation;

namespace Implementation.Validator
{
    public class ReservationValidator<T> : AbstractValidator<T> where T : IReservationCommandDto
    {
        protected BookLibraryContext _context;

        public ReservationValidator(BookLibraryContext context)
        {
            _context = context;

            RuleFor(x => x.StartTime)
                .NotEmpty()
                .DependentRules(() => {
                    RuleFor(x => x.StartTime)
                    .Must((dto, x) => dto.StartTime.ToDate() < dto.EndTime.ToDate())
                    .WithMessage("Start date cannot be after or equal to end date");

                    RuleFor(x => x.StartTime)
                   .Must((dto, x) => dto.StartTime.ToDate() > System.DateTime.Now)
                   .WithMessage("Start date cannot be in past.");
                });

            RuleFor(x => x.EndTime)
                .NotEmpty()
                .DependentRules(() => {
                    RuleFor(x => x.EndTime)
                    .Must((dto, x) => (dto.EndTime.ToDate() - dto.StartTime.ToDate()).TotalDays <= 30)
                    .WithMessage("Reservation cannot be longer then 30 days");
                });

            RuleFor(x => x.UserId)
                .NotEmpty()
                .DependentRules(() => {
                    RuleFor(x => x.UserId)
                    .Must(x => UserExists(x))
                    .WithMessage("User with id = {PropertyValue} does not exist.");
                });

            RuleFor(x => x.BookIds).Must((dto, x) => dto.BookIds != null && dto.BookIds.Count > 0).WithMessage("At least one book is necessery.");

            RuleForEach(x => x.BookIds).ChildRules(id =>
            {
                id.RuleFor(x => x)
                .Must(x => BookExists(x))
                .WithMessage("Book with id = {PropertyValue} does not exist.'")
                .DependentRules(() => {
                    id.RuleFor(x => x)
                    .Must(x => IsBookAvailable(x))
                    .WithMessage("Book with id = {PropertyValue} is not available.'");
                });
            });

        }

        public bool UserExists(int id)
        {
            return _context.Users.Find(id) is not null;
        }

        private bool BookExists(int id)
        {
            return _context.Books.Find(id) is not null;
        }

        private bool IsBookAvailable(int id )
        {
            return _context.Books.Find(id).AvailableUnits > 0;
        }
    }
}

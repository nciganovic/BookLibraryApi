using Application.Dto.Reservation;
using DataAccess;
using FluentValidation;

namespace Implementation.Validator
{
    public class ChangeReservationValidator : ReservationValidator<ChangeReservationDto>
    {
        public ChangeReservationValidator(BookLibraryContext context) : base(context)
        {
            RuleFor(x => x.Id)
                .Must(x => ReservationExist(x))
                .WithMessage("Reservation with id {PropertyValue} does not exist.")
                .DependentRules(() => {
                    RuleFor(x => x.Id)
                    .Must((dto, x) => IsFutureReservation(dto))
                    .WithMessage("Only future reservations can be edited.");
                });
        }

        public bool ReservationExist(int id)
        {
            return _context.Reservations.Find(id) is not null;
        }

        public bool IsFutureReservation(ChangeReservationDto dto)
        {
            return _context.Reservations.Find(dto.Id).StartTime > System.DateTime.Now;
        }
    }
}

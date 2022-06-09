using Application.Dto.Reservation;
using Application.Interfaces;

namespace Application.Queries.Reservations
{
    public interface IGetOneReservationQuery : IQuery<int, ReservationResultDto>
    {
    }
}

using Application.Dto.Reservation;
using Application.Interfaces;
using Application.Searches;
using System.Collections.Generic;

namespace Application.Queries.Reservations
{
    public interface IGetReservationsQuery : IQuery<ReservationSearch, IEnumerable<ReservationResultDto>>
    {
    }
}

using Application.Dto.Reservation;
using Application.Queries.Reservations;
using AutoMapper;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Implementation.Queries.ReservationQueries
{
    public class EfGetOneReservationQuery : BaseQuery<Reservation>, IGetOneReservationQuery
    {
        private IMapper _mapper;

        public EfGetOneReservationQuery(BookLibraryContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 114;

        public string Name => "Get one reservation";

        public ReservationResultDto Execute(int search)
        {
            Reservation reservation = context.Reservations
                .Include(x => x.Books).ThenInclude(x => x.Authors)
                .Include(x => x.Books).ThenInclude(x => x.Format)
                .Include(x => x.Books).ThenInclude(x => x.Publisher)
                .Include(x => x.Books).ThenInclude(x => x.Category)
                .Include(x => x.Books).ThenInclude(x => x.Language)
                .Include(x => x.User)
                .Include(x => x.User.Role)
                .Include(x => x.User.Membership)
                .FirstOrDefault(x => x.Id == search);
            return _mapper.Map<Reservation, ReservationResultDto>(reservation);
        }
    }
}

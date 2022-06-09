using Application.Dto.Reservation;
using Application.Extensions;
using Application.Queries.Reservations;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.ReservationQueries
{
    public class EfGetReservationsQuery : BaseQuery<Reservation>, IGetReservationsQuery
    {
        private IMapper _mapper;

        public EfGetReservationsQuery(BookLibraryContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 115;

        public string Name => "Get reservations query";

        public IEnumerable<ReservationResultDto> Execute(ReservationSearch search)
        {
            var query = context.Reservations
                .Include(x => x.Books).ThenInclude(x => x.Authors)
                .Include(x => x.Books).ThenInclude(x => x.Format)
                .Include(x => x.Books).ThenInclude(x => x.Publisher)
                .Include(x => x.Books).ThenInclude(x => x.Category)
                .Include(x => x.Books).ThenInclude(x => x.Language)
                .Include(x => x.User)
                .Include(x => x.User.Role)
                .Include(x => x.User.Membership)
                .AsQueryable();

            if (search.StartTime is not null)
                query = query.Where(x => x.StartTime >= search.StartTime.ToDate());

            if (search.EndTime is not null)
                query = query.Where(x => x.EndTime <= search.EndTime.ToDate());

            if (search.UserId is not null)
                query = query.Where(x => x.UserId == search.UserId);

            if (search.BookId is not null)
                query = query.Where(x => x.Books.Any(y => y.Id == search.BookId));

            BasicFilter(ref query, search);

            return query.OrderBy(x => x.StartTime).Select(x => _mapper.Map<Reservation, ReservationResultDto>(x));
        }
    }
}

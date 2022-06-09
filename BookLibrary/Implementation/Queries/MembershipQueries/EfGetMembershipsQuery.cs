using Application.Dto.Membership;
using Application.Queries.Memberships;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Implementation.Queries.MembershipQueries
{
    public class EfGetMembershipsQuery : BaseQuery<Membership>, IGetMembershipsQuery
    {
        private IMapper _mapper;

        public EfGetMembershipsQuery(BookLibraryContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 15;

        public string Name => "Get memberships";

        public IEnumerable<MembershipResultDto> Execute(MembershipSearch search)
        {
            var query = this.context.Memberships.AsQueryable();

            if (search.Name != null)
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));

            if (search.Description != null)
                query = query.Where(x => x.Description.ToLower().Contains(search.Description.ToLower()));

            if (search.MonthlyFeeFrom != null)
                query = query.Where(x => search.MonthlyFeeFrom <= x.MonthlyFee);

            if (search.MonthlyFeeTo != null)
                query = query.Where(x => search.MonthlyFeeTo >= x.MonthlyFee);

            BasicFilter(ref query, search);

            return query.OrderBy(x => x.MonthlyFee).Select(x => _mapper.Map<Membership, MembershipResultDto>(x)).ToList();
        }
    }
}

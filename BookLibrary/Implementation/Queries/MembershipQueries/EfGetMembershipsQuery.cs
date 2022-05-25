using Application.Dto;
using Application.Filter;
using Application.Queries.Memberships;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Domain;
using Implementation.EfCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.MembershipQueries
{
    public class EfGetMembershipsQuery : BaseQuery<Membership>, IGetMembershipsQuery
    {
        private IMapper _mapper;

        public EfGetMembershipsQuery(BookLibraryContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 5;

        public string Name => "Get memberships";

        public IEnumerable<MembershipResultDto> Execute(MembershipSearch search)
        {
            var query = this.context.Memberships.AsQueryable();

            BasicFilter(ref query, search);

            return query.OrderBy(x => x.CreatedAt).Select(x => _mapper.Map<Membership, MembershipResultDto>(x)).ToList();
        }
    }
}

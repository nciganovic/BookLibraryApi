using Application.Dto.Membership;
using Application.Queries.Memberships;
using AutoMapper;
using DataAccess;
using Domain;

namespace Implementation.Queries.MembershipQueries
{
    public class EfGetOneMembershipQuery : BaseQuery<Membership>, IGetOneMembershipQuery
    {
        private IMapper _mapper;

        public EfGetOneMembershipQuery(BookLibraryContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 14;

        public string Name => "Get one membership";

        public MembershipResultDto Execute(int search)
        {
            Membership membership = context.Memberships.Find(search);
            if (membership.DeletedAt != null)
                return null;
            return _mapper.Map<Membership, MembershipResultDto>(membership);
        }
    }
}

using Application.Dto;
using Application.Queries.Memberships;
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
    public class EfGetOneMembershipQuery : BaseQuery<Membership>, IGetOneMembershipQuery
    {
        private IMapper _mapper;

        public EfGetOneMembershipQuery(BookLibraryContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 4;

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

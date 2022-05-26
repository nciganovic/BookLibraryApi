using Application.Dto.Membership;
using Application.Interfaces;
using Application.Searches;
using System.Collections.Generic;

namespace Application.Queries.Memberships
{
    public interface IGetMembershipsQuery : IQuery<MembershipSearch, IEnumerable<MembershipResultDto>>
    {
    }
}

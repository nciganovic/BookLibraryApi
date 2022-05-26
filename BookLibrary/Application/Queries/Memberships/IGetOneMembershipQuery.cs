using Application.Dto.Membership;
using Application.Interfaces;

namespace Application.Queries.Memberships
{
    public interface IGetOneMembershipQuery : IQuery<int, MembershipResultDto>
    {
    }
}

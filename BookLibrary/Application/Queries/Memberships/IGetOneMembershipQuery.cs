using Application.Dto;
using Application.Interfaces;

namespace Application.Queries.Memberships
{
    public interface IGetOneMembershipQuery : IQuery<int, MembershipResultDto>
    {
    }
}

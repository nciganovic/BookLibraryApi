using Application.Dto.User;
using Application.Interfaces;
using Application.Searches;

namespace Application.Queries.Users
{
    public interface IGetUsersQuery : IQuery<UserSearch, UserResultDto>
    {
    }
}

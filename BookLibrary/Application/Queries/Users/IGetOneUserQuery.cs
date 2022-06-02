using Application.Dto.User;
using Application.Interfaces;

namespace Application.Queries.Users
{
    public interface IGetOneUserQuery : IQuery<int, UserResultDto>
    {
    }
}

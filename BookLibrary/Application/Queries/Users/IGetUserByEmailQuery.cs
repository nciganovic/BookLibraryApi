using Application.Dto.User;
using Application.Interfaces;

namespace Application.Queries.Users
{
    public interface IGetUserByEmailQuery : IQuery<string, UserResultDto>
    {
    }
}

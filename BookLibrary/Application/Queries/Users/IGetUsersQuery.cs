using Application.Dto.User;
using Application.Interfaces;
using Application.Searches;
using System.Collections.Generic;

namespace Application.Queries.Users
{
    public interface IGetUsersQuery : IQuery<UserSearch, IEnumerable<UserResultDto>>
    {
    }
}

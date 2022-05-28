using Application.Dto.Role;
using Application.Interfaces;
using Application.Searches;

namespace Application.Queries.Roles
{
    public interface IGetOneRoleQuery : IQuery<int, RoleResultDto>
    {
    }
}

using Application.Dto.Role;
using Application.Interfaces;
using Application.Searches;

namespace Application.Queries.Roles
{
    public interface IGetRolesQuery : IQuery<RoleSearch, RoleResultDto>
    {
    }
}

using Application.Dto.Role;
using Application.Interfaces;
using Application.Searches;
using System.Collections.Generic;

namespace Application.Queries.Roles
{
    public interface IGetRolesQuery : IQuery<RoleSearch, IEnumerable<RoleResultDto>>
    {
    }
}

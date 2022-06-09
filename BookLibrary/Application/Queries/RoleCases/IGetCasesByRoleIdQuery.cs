using Application.Interfaces;
using System.Collections.Generic;

namespace Application.Queries.RoleCases
{
    public interface IGetCasesByRoleIdQuery : IQuery<int, IEnumerable<int>>
    {
    }
}

using Application.Dto.Role;
using Application.Queries.Roles;
using Application.Searches;
using DataAccess;
using Domain;
using System;

namespace Implementation.Queries.RoleQueries
{
    public class EfGetRolesQuery : BaseQuery<Role>, IGetRolesQuery
    {
        public EfGetRolesQuery(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 25;

        public string Name => "Get roles";

        public RoleResultDto Execute(RoleSearch search)
        {
            throw new NotImplementedException();
        }
    }
}

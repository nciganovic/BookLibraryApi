using Application.Queries.Roles;
using Application.Searches;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.RoleQueries
{
    public class EfGetOneRoleQuery : BaseQuery<Role>, IGetOneRoleQuery
    {
        public EfGetOneRoleQuery(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 24;

        public string Name => "Get one role";

        public RoleSearch Execute(int search)
        {
            throw new NotImplementedException();
        }
    }
}

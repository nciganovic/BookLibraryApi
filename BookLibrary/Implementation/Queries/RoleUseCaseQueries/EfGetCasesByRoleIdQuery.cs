using Application.Queries.RoleCases;
using DataAccess;
using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Implementation.Queries.RoleUseCaseQueries
{
    public class EfGetCasesByRoleIdQuery : BaseQuery<RoleUserCase>, IGetCasesByRoleIdQuery
    {

        public EfGetCasesByRoleIdQuery(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 124;

        public string Name => "Get cases by role id query";

        public IEnumerable<int> Execute(int search)
        {
            var query = context.RoleUserCases.AsQueryable();

            query = query.Where(x => x.RoleId == search);

            return query.Select(x => x.UseCaseId).ToList();
        }
    }
}

using Application.Dto.RoleCase;
using Application.Queries.RoleCases;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.RoleUseCaseQueries
{
    public class EfGetOneRoleUseCaseQuery : BaseQuery<RoleUserCase>, IGetOneRoleCaseQuery
    {
        public EfGetOneRoleUseCaseQuery(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 123;

        public string Name => "Get one role case query";

        public RoleUserCase Execute(RoleCaseDto search)
        {
            var item = context.RoleUserCases
                .FirstOrDefault(x => x.RoleId == search.RoleId
                && x.UseCaseId == search.UseCaseId);

            return item;
        }
    }
}

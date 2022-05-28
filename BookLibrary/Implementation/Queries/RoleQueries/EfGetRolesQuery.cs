using Application.Dto.Role;
using Application.Queries.Roles;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Implementation.Queries.RoleQueries
{
    public class EfGetRolesQuery : BaseQuery<Role>, IGetRolesQuery
    {
        private IMapper _mapper;

        public EfGetRolesQuery(BookLibraryContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 25;

        public string Name => "Get roles";

        public IEnumerable<RoleResultDto> Execute(RoleSearch search)
        {
            var query = this.context.Roles.AsQueryable();

            BasicFilter(ref query, search);

            if (search.Name != null)
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));

            return query.OrderBy(x => x.Name).Select(x => _mapper.Map<Role, RoleResultDto>(x)).ToList();
        }
    }
}

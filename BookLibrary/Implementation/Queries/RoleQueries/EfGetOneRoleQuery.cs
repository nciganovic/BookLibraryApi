using Application.Dto.Role;
using Application.Queries.Roles;
using Application.Searches;
using AutoMapper;
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
        private IMapper _mapper;

        public EfGetOneRoleQuery(BookLibraryContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 24;

        public string Name => "Get one role";

        public RoleResultDto Execute(int search)
        {
            Role role = context.Roles.Find(search);
            if (role?.DeletedAt != null)
                return null;
            return _mapper.Map<Role, RoleResultDto>(role);
        }
    }
}

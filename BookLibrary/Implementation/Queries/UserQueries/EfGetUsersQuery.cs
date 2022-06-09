using Application.Dto.User;
using Application.Interfaces;
using Application.Queries.Users;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.UserQueries
{
    public class EfGetUsersQuery : BaseQuery<User>, IGetUsersQuery
    {
        private IMapper _mapper;

        public EfGetUsersQuery(BookLibraryContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 95;

        public string Name => "Get users query";

        public IEnumerable<UserResultDto> Execute(UserSearch search)
        {
            var query = context.Users.Include(x => x.Membership).Include(x => x.Role).AsQueryable();

            if (search.FirstName != null)
                query = query.Where(x => x.FirstName.Contains(search.FirstName));

            if (search.LastName != null)
                query = query.Where(x => x.LastName.Contains(search.LastName));

            if (search.Email != null)
                query = query.Where(x => x.Email.Contains(search.Email));

            if (search.RoleId != 0)
                query = query.Where(x => x.RoleId == search.RoleId);

            if (search.MembershipId != 0)
                query = query.Where(x => x.MembershipId == search.MembershipId);

            BasicFilter(ref query, search);

            return query.OrderBy(x => x.Email).Select(x => _mapper.Map<User, UserResultDto>(x));
        }
    }
}

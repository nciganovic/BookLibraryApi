using Application.Dto.User;
using Application.Queries.Users;
using AutoMapper;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Implementation.Queries.UserQueries
{
    public class EfGetOneUserQuery : BaseQuery<User>, IGetOneUserQuery
    {
        private IMapper _mapper;

        public EfGetOneUserQuery(BookLibraryContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 94;

        public string Name => "Get one user";

        public UserResultDto Execute(int search)
        {
            User user = context.Users.Include(x => x.Membership).Include(x => x.Role).Where(x => x.Id == search).FirstOrDefault();
            return _mapper.Map<User, UserResultDto>(user);
        }
    }
}

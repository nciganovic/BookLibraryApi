using Application.Dto.User;
using Application.Queries.Users;
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
    public class EfGetUserByEmailCommand : BaseQuery<User>, IGetUserByEmailQuery
    {
        private IMapper _mapper;

        public EfGetUserByEmailCommand(BookLibraryContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 96;

        public string Name => "Get user by email";

        public UserResultDto Execute(string search)
        {
            User user = context.Users.Include(x => x.Membership).Include(x => x.Role).Where(x => x.Email == search).FirstOrDefault();
            return _mapper.Map<User, UserResultDto>(user);
        }
    }
}

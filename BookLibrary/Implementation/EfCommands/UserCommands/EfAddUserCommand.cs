using Application.Commands.Users;
using Application.Interfaces;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands.UserCommands
{
    public class EfAddUserCommand : BaseCommand, IAddUserCommand
    {
        public EfAddUserCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 91;

        public string Name => "Add user";

        public void Execute(User request)
        {
            context.Users.Add(request);
            context.SaveChanges();
        }
    }
}

using Application.Commands.Users;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands.UserCommands
{
    public class EfChangeUserCommand : BaseCommand, IChangeUserCommand
    {
        public EfChangeUserCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 92;

        public string Name => "Change user";

        public void Execute(User request)
        {
            User item = context.Users.Find(request.Id);

            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            request.UpdatedAt = DateTime.Now;

            var entity = context.Users.Attach(request);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}

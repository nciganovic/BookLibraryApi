using Application.Commands.Users;
using Application.Exceptions;
using DataAccess;
using Domain;
using System;

namespace Implementation.EfCommands.UserCommands
{
    public class EfRemoveUserCommand : BaseCommand, IRemoveUserCommand
    {
        public EfRemoveUserCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 93;

        public string Name => "Remove user";

        public void Execute(int request)
        {
            User item = context.Users.Find(request);

            if (item == null)
                throw new EntityNotFoundException(request, "User");

            item.DeletedAt = DateTime.Now;

            context.Users.Update(item);
            context.SaveChanges();
        }
    }
}

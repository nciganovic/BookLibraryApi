using Application.Commands.Roles;
using Application.Exceptions;
using DataAccess;
using Domain;
using System;

namespace Implementation.EfCommands.RoleCommands
{
    public class EfRemoveRoleCommand : BaseCommand, IRemoveRoleCommand
    {
        public EfRemoveRoleCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 23;

        public string Name => "Remove role";

        public void Execute(int request)
        {
            Role item = context.Roles.Find(request);

            if (item == null)
                throw new EntityNotFoundException(request, "Role");

            item.DeletedAt = DateTime.Now;

            context.Roles.Update(item);
            context.SaveChanges();
        }
    }
}

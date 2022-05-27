using Application.Commands.Roles;
using DataAccess;
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
            throw new NotImplementedException();
        }
    }
}

using Application.Commands.RoleCases;
using DataAccess;
using Domain;

namespace Implementation.EfCommands.RoleCaseCommands
{
    public class EfRemoveRoleCaseCommand : BaseCommand, IRemoveRoleCaseCommand
    {

        public EfRemoveRoleCaseCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 122;

        public string Name => "Remove use case command";

        public void Execute(RoleUserCase request)
        {
            context.Remove(request);
            context.SaveChanges();
        }
    }
}

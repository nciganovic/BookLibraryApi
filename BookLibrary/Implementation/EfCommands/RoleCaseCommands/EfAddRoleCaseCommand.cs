using Application.Commands.RoleCases;
using DataAccess;
using Domain;

namespace Implementation.EfCommands.RoleCaseCommands
{
    public class EfAddRoleCaseCommand : BaseCommand, IAddRoleCaseCommand
    {

        public EfAddRoleCaseCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 121;

        public string Name => "Add role use case command";

        public void Execute(RoleUserCase request)
        {
            context.Add(request);
            context.SaveChanges();
        }
    }
}

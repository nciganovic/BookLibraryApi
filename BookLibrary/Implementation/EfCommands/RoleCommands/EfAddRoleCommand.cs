using Application.Commands.Roles;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands.RoleCommands
{
    public class EfAddRoleCommand : BaseCommand, IAddRoleCommand
    {
        public EfAddRoleCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 21;

        public string Name => "Add role";

        public void Execute(Role request)
        {
            context.Add(request);
            context.SaveChanges();
        }
    }
}

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
    public class EfChanegRoleCommand : BaseCommand, IChangeRoleCommand
    {
        public EfChanegRoleCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 22;

        public string Name => "Change role";

        public void Execute(Role request)
        {
            throw new NotImplementedException();
        }
    }
}

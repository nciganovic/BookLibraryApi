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
    public class EfChangeRoleCommand : BaseCommand, IChangeRoleCommand
    {
        public EfChangeRoleCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 22;

        public string Name => "Change role";

        public void Execute(Role request)
        {
            Role item = context.Roles.Find(request.Id);

            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            request.UpdatedAt = DateTime.Now;

            var entity = context.Roles.Attach(request);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}

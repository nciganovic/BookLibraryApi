using Application.Commands.MembershipCommands;
using DataAccess;
using Domain;
using System;

namespace Implementation.EfCommands.MembershipCommands
{
    public class EfChangeMembershipCommand : BaseCommand, IChangeMembershipCommand
    {
        public EfChangeMembershipCommand(BookLibraryContext context): base(context)
        {

        }

        public int Id => 12;

        public string Name => "Change Membership";

        public void Execute(Membership request)
        {
            Membership item = context.Memberships.Find(request.Id);

            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            request.UpdatedAt = DateTime.Now;

            var entity = context.Memberships.Attach(request);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}

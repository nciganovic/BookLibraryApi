using System;
using Application.Commands.MembershipCommands;
using Domain;
using DataAccess;

namespace Implementation.EfCommands.MembershipCommands
{
    public class EfAddMembershipCommand : BaseCommand, IAddMembershipCommand
    {
        public EfAddMembershipCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 11;

        public string Name => "Add Membership";

        public void Execute(Membership request)
        {
            context.Add(request);
            context.SaveChanges();
        }
    }
}

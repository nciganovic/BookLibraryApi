using Application.Commands.MembershipCommands;
using Application.Exceptions;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
namespace Implementation.EfCommands.MembershipCommands
{
    public class EfRemoveMembershipCommand : BaseCommand, IRemoveMembershipCommand
    {
        public EfRemoveMembershipCommand(BookLibraryContext context) : base(context)
        {
            
        }
        public int Id => 3;

        public string Name => "Remove Membership";

        public void Execute(int request)
        {
            Membership item = context.Memberships.Find(request);

            if (item == null)
                throw new EntityNotFoundException(request, "Membership");

            item.DeletedAt = DateTime.Now;

            context.Memberships.Update(item);
            context.SaveChanges();
        }
    }
}

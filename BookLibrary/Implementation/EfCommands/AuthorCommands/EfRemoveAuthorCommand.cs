using Application.Commands.Authors;
using Application.Exceptions;
using DataAccess;
using Domain;
using System;

namespace Implementation.EfCommands.FormatCommands
{
    public class EfRemoveAuthorCommand : BaseCommand, IRemoveAuthorCommand
    {
        public EfRemoveAuthorCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 73;

        public string Name => "Remove author";

        public void Execute(int request)
        {
            Author item = context.Authors.Find(request);

            if (item == null)
                throw new EntityNotFoundException(request, "Author");

            item.DeletedAt = DateTime.Now;

            context.Authors.Update(item);
            context.SaveChanges();
        }
    }
}

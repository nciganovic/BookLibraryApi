using Application.Commands.Publishers;
using Application.Exceptions;
using DataAccess;
using Domain;
using System;

namespace Implementation.EfCommands.PublisherCommands
{
    public class EfRemovePublisherCommand : BaseCommand, IRemovePublisherCommand
    {
        public EfRemovePublisherCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 43;

        public string Name => "Remove publisher";

        public void Execute(int request)
        {
            Publisher item = context.Publishers.Find(request);

            if (item == null)
                throw new EntityNotFoundException(request, "Publisher");

            item.DeletedAt = DateTime.Now;

            context.Publishers.Update(item);
            context.SaveChanges();
        }
    }
}

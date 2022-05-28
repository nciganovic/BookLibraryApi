using Application.Commands.Publishers;
using DataAccess;
using Domain;
using System;

namespace Implementation.EfCommands.PublisherCommands
{
    public class EfChangePublisherCommand : BaseCommand, IChangePublisherCommand
    {
        public EfChangePublisherCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 42;

        public string Name => "Change publisher";

        public void Execute(Publisher request)
        {
            Publisher item = context.Publishers.Find(request.Id);

            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            request.UpdatedAt = DateTime.Now;

            var entity = context.Publishers.Attach(request);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}

using Application.Commands.Publishers;
using DataAccess;
using Domain;
using System;

namespace Implementation.EfCommands.PublisherCommands
{
    public class EfChangePublisherCommand : BaseCommand, IChangePublisherCommnad
    {
        public EfChangePublisherCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 42;

        public string Name => "Change publisher";

        public void Execute(Publisher request)
        {
            throw new NotImplementedException();
        }
    }
}

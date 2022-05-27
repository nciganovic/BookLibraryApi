using Application.Commands.Publishers;
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
            throw new NotImplementedException();
        }
    }
}

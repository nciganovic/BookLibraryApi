using Application.Commands.Publishers;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands.PublisherCommands
{
    public class EfAddPublisherCommand : BaseCommand, IAddPublisherCommand
    {
        public EfAddPublisherCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 41;

        public string Name => "Add publisher";

        public void Execute(Publisher request)
        {
            context.Add(request);
            context.SaveChanges();
        }
    }
}

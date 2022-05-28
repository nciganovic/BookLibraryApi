using Application.Commands.Authors;
using DataAccess;
using Domain;
using System;

namespace Implementation.EfCommands.FormatCommands
{
    public class EfAddAuthorCommand : BaseCommand, IAddAuthorCommand
    {
        public EfAddAuthorCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 71;

        public string Name => "Add auhtor";

        public void Execute(Author request)
        {
            context.Add(request);
            context.SaveChanges();
        }
    }
}

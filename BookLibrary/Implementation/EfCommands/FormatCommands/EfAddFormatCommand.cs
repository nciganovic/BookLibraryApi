using Application.Commands.Formats;
using DataAccess;
using Domain;
using System;

namespace Implementation.EfCommands.FormatCommands
{
    public class EfAddFormatCommand : BaseCommand, IAddFormatCommand
    {
        public EfAddFormatCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 51;

        public string Name => "Add publisher";

        public void Execute(Format request)
        {
            context.Add(request);
            context.SaveChanges();
        }
    }
}

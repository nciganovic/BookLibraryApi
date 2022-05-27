using Application.Commands.Formats;
using DataAccess;
using System;

namespace Implementation.EfCommands.FormatCommands
{
    public class EfRemoveFormatCommand : BaseCommand, IRemoveFormatCommand
    {
        public EfRemoveFormatCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 53;

        public string Name => "Remove format";

        public void Execute(int request)
        {
            throw new NotImplementedException();
        }
    }
}

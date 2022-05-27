using Application.Commands.Authors;
using DataAccess;
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
            throw new NotImplementedException();
        }
    }
}

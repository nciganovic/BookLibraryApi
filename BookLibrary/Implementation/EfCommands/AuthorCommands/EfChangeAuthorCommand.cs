using Application.Commands.Authors;
using DataAccess;
using Domain;
using System;

namespace Implementation.EfCommands.FormatCommands
{
    public class EfChangeAuthorCommand : BaseCommand, IChangeAuthorCommand
    {
        public EfChangeAuthorCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 72;

        public string Name => "Change auhtor";

        public void Execute(Author request)
        {
            throw new NotImplementedException();
        }
    }
}

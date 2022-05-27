using Application.Commands.Languages;
using DataAccess;
using System;

namespace Implementation.EfCommands.LanguageCommands
{
    public class EfRemoveLanguageCommand : BaseCommand, IRemoveLanguageCommand
    {
        public EfRemoveLanguageCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 33;

        public string Name => "Remove language";

        public void Execute(int request)
        {
            throw new NotImplementedException();
        }
    }
}

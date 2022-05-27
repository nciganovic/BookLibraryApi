using Application.Commands.Languages;
using DataAccess;
using Domain;
using System;

namespace Implementation.EfCommands.LanguageCommands
{
    public class EfChangeLanguageCommand : BaseCommand, IChangeLanguageCommand
    {
        public EfChangeLanguageCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 32;

        public string Name => "Change language";

        public void Execute(Language request)
        {
            throw new NotImplementedException();
        }
    }
}

using Application.Commands.Languages;
using DataAccess;
using Domain;
using System;

namespace Implementation.EfCommands.LanguageCommands
{
    public class EfAddLanguageCommand : BaseCommand, IAddLanguageCommand
    {
        public EfAddLanguageCommand(BookLibraryContext context) : base(context)
        {

        }

        public int Id => 31;

        public string Name => "Add language";

        public void Execute(Language request)
        {
            context.Add(request);
            context.SaveChanges();
        }
    }
}

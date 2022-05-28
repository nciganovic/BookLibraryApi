using Application.Commands.Languages;
using Application.Exceptions;
using DataAccess;
using Domain;
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
            Language item = context.Languages.Find(request);

            if (item == null)
                throw new EntityNotFoundException(request, "Language");

            item.DeletedAt = DateTime.Now;

            context.Languages.Update(item);
            context.SaveChanges();
        }
    }
}
